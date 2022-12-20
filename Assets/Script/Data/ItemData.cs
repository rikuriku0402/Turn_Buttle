using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    Sprite _itemSprite;

    string _itemName;

    ItemDataBase.ItemType _itemType;

    string _itemInformation;

    public ItemData(Sprite image, string itemName, ItemDataBase.ItemType itemType, string information)
    {
        this._itemSprite = image;
        this._itemName = itemName;
        this._itemType = itemType;
        this._itemInformation = information;
    }

    public Sprite GetItemSprite() => _itemSprite;

    public string GetItemName() => _itemName;

    public ItemDataBase.ItemType GetItemType() => _itemType;

    public string GetItemInformation() => _itemInformation;
}
