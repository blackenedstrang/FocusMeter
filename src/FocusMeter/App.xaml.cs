using System;
using System.Configuration;
using System.Windows.Forms;
using FocusMeter.Infrastructure;
using FocusMeter.Model;
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
    }
}
