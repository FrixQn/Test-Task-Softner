namespace TestProject.Core
{
    public static class EventsCollection
    {
        /// <summary>
        /// Callback from the FSM. The handled method should store 2 parameters
        /// <see cref="FSMCallbackName"/> to define the callback name and 
        /// <see cref="FSMStatePhase"/> to define current state type
        /// <code>Example:
        /// MyMethod(<see cref="FSMCallbackName"/> name, <see cref="FSMStatePhase"/> phase)</code>
        /// </summary>
        public const string FSMCallback = "FSMCallback";
    }
}
