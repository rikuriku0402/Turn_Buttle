using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStatus : MonoBehaviour
{
    [SerializeField]
    [Header("アイテムデータベース")]
    ItemDataBase _itemDataBase;

    Dictionary<string, bool> _itemFlags = new();

    private void Start()
    {
        foreach (var item in _itemDataBase.GetItemDataList())
        {
            _itemFlags.Add(item.GetItemName(), false);
        }
        _itemFlags["FlashLight"] = true;
        _itemFlags["BroadSword"] = true;
        _itemFlags["HandGun"] = true;
    }

    public bool GetItemFlag(string itemName) => _itemFlags[itemName];
}
