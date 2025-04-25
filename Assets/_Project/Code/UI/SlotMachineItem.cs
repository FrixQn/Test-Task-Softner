using UnityEngine;

namespace TestProject.UI
{
    public class SlotMachineItem : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void Animate(bool isStillAnimate)
        {
            _animator.SetBool("Blur", isStillAnimate);
        }
    }
}
