using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

namespace TestProject.Core
{
    public class VFXManager : MonoBehaviourExtBind
    {
        [SerializeField] private ParticleSystem _confetti;
        [SerializeField] private BindName _afterRollEvent;

        [Bind("{_afterRollEvent.name}")]
        private void OnStopButtonClicked()
        {
            _confetti.Play();
        }
    }
}
