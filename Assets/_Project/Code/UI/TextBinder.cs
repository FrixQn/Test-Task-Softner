using AxGrid.Base;
using AxGrid.Model;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextBinder : MonoBehaviourExtBind
{
    private TextMeshProUGUI _text;
    [SerializeField] private string _fieldName;

    [OnAwake]
    private void Initialize()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Model.EventManager.AddAction(_fieldName, () => { Debug.Log("Start button clicked"); });
    }

    [Bind("On{_fieldName}Changed")]
    private void OnValueChanged(string data)
    {
        _text.text = data;
    }
}
