using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSlotScript : MonoBehaviour
{
    [SerializeField]
    [Header("�A�C�e�����̃X���b�g�v���n�u")]
    GameObject _slot;

    [SerializeField]
    [Header("��l���̃X�e�[�^�X")]
    MyStatus _mySuatus;

    [SerializeField]
    [Header("�A�C�e���f�[�^�x�[�X")]
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
