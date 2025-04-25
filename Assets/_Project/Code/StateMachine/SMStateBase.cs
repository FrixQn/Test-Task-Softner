using AxGrid.Base;
using AxGrid.FSM;
using TestProject.Core;

namespace TestProject.FSM
{
    public abstract class SMStateBase : FSMState
    {
        protected FSMCallbackName _callbackName;
        public SMStateBase(FSMCallbackName callbackName)
        {
            _callbackName = callbackName;
        }

        [Enter((int)RunLevel.High)]
        private void Enter()
        {
            InvokeCallback(FSMStatePhase.Enter);
        }

        [Exit((int)RunLevel.High)]
        private void Exit()
        {
            InvokeCallback(FSMStatePhase.Exit);
        }

        protected void InvokeCallback(FSMStatePhase phase)
        {
            Model.EventManager.Invoke(EventsCollection.FSMCallback, _callbackName, phase);
        }
    }
}
