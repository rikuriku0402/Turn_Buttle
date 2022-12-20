using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSlotScript : MonoBehaviour
{
    [SerializeField]
    [Header("アイテム情報のスロットプレハブ")]
    GameObject _slot;

    [SerializeField]
    [Header("主人公のステータス")]
    MyStatus _mySuatus;

    [SerializeField]
    [Header("アイテムデータベース")]
    ItemDataBase _itemDataBase;

    private void OnEnable()
    {
        CreateSlot(_itemDataBase.GetItemDataList());
    }

    private void CreateSlot(List<ItemData> itemList)
    {
        int i = 0;

        foreach (var item in itemList)
        {
            if (_mySuatus.GetItemFlag(item.GetItemName()))
            {
                var instanceSlot = Instantiate(_slot, transform);

                instanceSlot.name = "ItemSlot" + i++;

                instanceSlot.transform.localScale = new Vector3(1f, 1f, 1f);

                instanceSlot.GetComponent<ProcessingSlot>().SetItemData(item);
            }
        }
    }
}
