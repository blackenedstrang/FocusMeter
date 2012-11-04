using System;

namespace FocusMeter.Model
{
    public class StateChangedEvent
    {
	    public string MachineName { get; set; }
	    public DateTimeOffset Date { get; set; }
	    public TimerState OldState { get; set; }
	    public TimerState NewState { get; set; }
    }
}