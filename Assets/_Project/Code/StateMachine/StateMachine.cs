using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using UnityEngine;
using TestProject.Core;

namespace TestProject.FSM
{
    public class StateMachine : MonoBehaviourExtBind
    {
        private const string FSM_IDLING_STATE = "Idling";
        private const string FSM_ROLLING_STATE = "Rolling";
        private const string FSM_STOPPING_STATE = "Stopping";
        [SerializeField] private BindName _startButtonClicked;
        [SerializeField] private BindName _stopButtonClicked;

        #region STATES
        #region Idling
        [State(FSM_IDLING_STATE, true)]
        private class IdlingState : SMStateBase
        {
            public IdlingState(FSMCallbackName name) : base(name) { }

            [One(0.01f)]
            public void Execute()
            {
                InvokeCallback(FSMStatePhase.Execute);
            }
            /*[Enter(1), One(0.01f)]
            public void SetupButtons()
            {
                Model.EventManager.Invoke(EventsCollection.FSMCallback, FSMCallbackName.Idle, FSMStatePhase.Enter);
            }*/
        }
        #endregion

        #region Rolling
        [State(FSM_ROLLING_STATE, true)]
        public class RollingState : SMStateBase
        {
            public RollingState(FSMCallbackName callbackName) : base(callbackName) { }

            /*[Enter(0)]
            public void Enter()
            {
                Model.EventManager.Invoke(EventsCollection.FSMCallback, FSMCallbackName.Roll, FSMStatePhase.Enter);
            }

            [Enter(1), One(0.01f)]
            public void DisplayViewState()
            {
                Model.EventManager.Invoke("RollingBegin");
            }*/

            [One(3f)]
            public void SetupButtons()
            {
                InvokeCallback(FSMStatePhase.Execute);
            }

            /*        [Exit]
                    public void Exit()
                    {
                        Debug.Log("Exit from the rolling state");
                    }*/
        }
        #endregion

        #region Idling
        [State(FSM_STOPPING_STATE, true)]
        public class StoppingState : SMStateBase
        {
            public StoppingState(FSMCallbackName callbackName) : base(callbackName)
            {

            }

            [One(1f)]
            private void LeaveState()
            {
                Parent.Change(FSM_IDLING_STATE);
            }
        }
        #endregion
        #endregion

        [OnAwake]
        private void Initialize()
        {
            Settings.Fsm = new AxGrid.FSM.FSM();
            Settings.Fsm.Add(new IdlingState(FSMCallbackName.Idle));
            Settings.Fsm.Add(new RollingState(FSMCallbackName.Roll));
            Settings.Fsm.Add(new StoppingState(FSMCallbackName.Stop));
        }

        [OnStart]
        private void RunFSM()
        {
            Settings.Fsm.Start("Idling");
        }

        [OnUpdate]
        private void Evaluate()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }

        [AxGrid.Model.Bind("{_startButtonClicked.name}")]
        private void OnStartButtonClicked()
        {
            Settings.Fsm.Change("Rolling");
        }

        [AxGrid.Model.Bind("{_stopButtonClicked.name}")]
        private void OnStopButtonClicked()
        {
            Settings.Fsm.Change("Stopping");
        }
    }
}
