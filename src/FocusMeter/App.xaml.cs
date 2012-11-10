using System;
using System.Configuration;
using System.Windows.Forms;
using FocusMeter.Infrastructure;
using FocusMeter.Model;
using Microsoft.Win32;
using Application = System.Windows.Application;
using Configuration = FocusMeter.Model.Configuration;

namespace FocusMeter
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static KeyboardHook hook;

		public static StateManager StateManager { get; set; }

		public App()
		{
			var useEmbeddedMode = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("UseEmbeddedMode"));

			DocumentStoreContainer.Initialize(useEmbeddedMode);

			StateManager = new StateManager(DocumentStoreContainer.DocumentStore, TimerState.NotWorking);

			var configuration = DocumentStoreContainer.DocumentStore.LoadConfiguration();
			if (configuration == null)
			{
				configuration = new Configuration
				{
					ShortcutKey = Keys.Enter,
					ShortcutModifierKeys = ModifierKeys.Control
				};
				DocumentStoreContainer.DocumentStore.SaveOrUpdateConfiguration(configuration);
			}
			RegisterKeyboardShortcuts(configuration);
			RegisterScreenLockHandlers();
		}

		public static void RegisterKeyboardShortcuts(Configuration configuration)
		{
			if (hook != null)
			{
				// don't rely on the gc here because the shortcut will stay active until cleanup
				hook.Dispose();
				hook = null;
			}

			hook = new KeyboardHook();
			hook.RegisterHotKey(configuration.ShortcutModifierKeys, configuration.ShortcutKey);
			hook.KeyPressed += (sender, args) => StateManager.ToggleDistraction();
		}

		private void RegisterScreenLockHandlers()
		{
			SystemEvents.SessionSwitch += SystemEvents_OnSessionSwitch;
		}

		private void SystemEvents_OnSessionSwitch(object sender, SessionSwitchEventArgs e)
		{
			if (e.Reason == SessionSwitchReason.SessionLock)
			{
				Dispatcher.Invoke((Action)(() => StateManager.ChangeState(TimerState.NotWorking)));
			}
			else if (e.Reason == SessionSwitchReason.SessionUnlock)
			{
				// not sure what to do here, so it is better to leave NotWorking
				//StateManager.ChangeState(TimerState.NotWorking);
			}
		}
	}
}
