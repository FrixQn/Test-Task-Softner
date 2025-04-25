using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BindName", menuName = MENU_NAME + "BindName")]
public class BindName : ScriptableObject
{
    protected const string MENU_NAME = "Project/Binding/";

    public static implicit operator string(BindName obj)
    {
        return obj == null ? string.Empty : obj.name;
    }
}


