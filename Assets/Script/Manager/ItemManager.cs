using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    Dictionary<Item, int> _numOfItem = new();

    [SerializeField]
    ItemDataBaseScriptableObject _itemDataBase;

    private void Start()
    {
        for (int i = 0; i < _itemDataBase.GetItemLists().Count; i++)
        {
            _numOfItem.Add(_itemDataBase.GetItemLists()[i], i);

            print(_itemDataBase.GetItemLists()[i].GetItemName() + ":" + _itemDataBase.GetItemLists()[i].GetInformation());
        }
        // 名前を探してきて説明する
        print(GetItem("Gun").GetInformation());

        // リストの何番目か
        print(_numOfItem[GetItem("Herb")]);
    }

    private Item GetItem(string searchName) => _itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
}
