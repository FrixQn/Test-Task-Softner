using AxGrid.Base;
using AxGrid.Model;
using TestProject.Core;
using UnityEngine;

namespace TestProject.UI
{
    public class SlotView : MonoBehaviourExtBind
    {
        [SerializeField] private SlotMachineReel[] _reels;
        [SerializeField] private SlotMachineAnimationSettings _animationSettings;
        [SerializeField] private BindNameBool _startButtonBind;
        [SerializeField] private BindNameBool _stopButtonBind;
        [SerializeField] private BindName _afterRollEvent;

        [OnAwake]
        private void Initialize()
        {
            foreach (var reel in _reels)
            {
                reel.ShuffleIcons();
            }
        }

        [Bind(EventsCollection.FSMCallback)]
        private async void OnFSMCallback(FSMCallbackName name, FSMStatePhase phase)
        {
            Model.Set(_startButtonBind, name == FSMCallbackName.Idle);
            Model.Set(_stopButtonBind, name == FSMCallbackName.Roll && phase == FSMStatePhase.Execute);

            if (name == FSMCallbackName.Roll)
            {
                if (phase == FSMStatePhase.Enter)
                {
                    int index = 0;
                    foreach (var reel in _reels)
                    {
                        reel.Roll(index * _animationSettings.ReelRollChainedDelay, _animationSettings.ReelRollSpeed);
                        index++;
                    }
                }

                if (phase == FSMStatePhase.Exit)
                {
                    foreach (var reel in _reels)
                    {
                        await reel.Stop(_animationSettings.ReelStopSpeedMultiplier);
                    }
                    Model.EventManager.Invoke(_afterRollEvent);
                }
            }
        }
    }
}
