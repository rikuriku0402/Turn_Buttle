using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName ="Item",menuName ="CreateItem")]
public class Item : ScriptableObject
{
    public enum KindOfItem
    {
        Weapon,
        UseItem
    }

    [SerializeField]
    KindOfItem _kindOfItem;

    [SerializeField]
    Sprite _icon;

    [SerializeField]
    string _itemName;

    [SerializeField]
    string _information;

    public KindOfItem GetKindOfItem() => _kindOfItem;

    public Sprite GetIcon() =>_icon;

    public string GetItemName() => _itemName;

    public string GetInformation() => _information;
}
