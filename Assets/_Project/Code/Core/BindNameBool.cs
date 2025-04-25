using UnityEngine;

[CreateAssetMenu(fileName = "BindName Bool", menuName = MENU_NAME + "BindName Bool")]
public class BindNameBool : BindName
{
    public static implicit operator string(BindNameBool obj)
    {
        return obj == null ? string.Empty : obj.name;
    }
}
