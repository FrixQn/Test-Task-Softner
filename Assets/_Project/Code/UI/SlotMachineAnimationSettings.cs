using UnityEngine;

namespace TestProject.UI
{
    [CreateAssetMenu(fileName = "SlotMachineAnimationSettings", menuName = "Project/SlotMachineAnimationSettings")]
    public class SlotMachineAnimationSettings : ScriptableObject
    {
        [field: SerializeField, Min(0f)] public float ReelRollChainedDelay { get; private set; } = 0f;
        [field: SerializeField, Min(1f)] public float ReelStopSpeedMultiplier { get; private set; } = 1f;
        [field: SerializeField, Min(0.1f)] public float ReelRollSpeed { get; private set; } = 0.25f;
    }
}
