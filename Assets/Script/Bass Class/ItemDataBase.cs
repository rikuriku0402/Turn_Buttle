using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public enum ItemType
    {
        Sword,
        Gun,
        Other
    }

    public List<ItemData> _itemDataList = new();

    private void Awake()
    {
        _itemDataList.Add(new ItemData(Resources.Load("Sword", typeof(Sprite)) as Sprite, "FlashLight", ItemType.Sword, "あれば便利なあたりを照らすライト"));
        _itemDataList.Add(new ItemData(Resources.Load("Sword", typeof(Sprite)) as Sprite, "BroadSword", ItemType.Sword, "普通の剣"));
        _itemDataList.Add(new ItemData(Resources.Load("Gun", typeof(Sprite)) as Sprite, "HandGun", ItemType.Gun, "標準のハンドガン"));
    }

    public List<ItemData> GetItemDataList() => _itemDataList;

    public ItemData GetItemData(string itemName)
    {
        foreach (var item in _itemDataList)
        {
            if (item.GetItemName() == itemName)
            {
                return item;
            }
        }
        return null;
    }
}
