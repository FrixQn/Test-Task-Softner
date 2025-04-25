using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonDataBind : MonoBehaviourExtBind
    {
        [SerializeField] private BindNameBool _interactable;
        [SerializeField] private BindName _clickEvent;
        private Button _button;

        [OnAwake]
        private void Init()
        {
            _button = GetComponent<Button>();
            _button.interactable = Model.GetBool(_interactable);
            _button.onClick.AddListener(ButtonClicked);
        }

        [Bind("On{_interactable.name}Changed")]
        private void OnChanged(bool state)
        {
            _button.interactable = state;
        }

        private void ButtonClicked()
        {
            Model.EventManager.Invoke(_clickEvent);
        }
    }
}
