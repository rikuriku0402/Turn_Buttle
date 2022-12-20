using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessingSlot : MonoBehaviour
{
    Text _informationText;

    GameObject _itemSlotTitleUIInstance;

    [SerializeField]
    [Header("自身のアイテムデータ")]
    ItemData _myItemData;

    [SerializeField]
    [Header("アイテムの名前を表示するテキストUIプレハブ")]
    GameObject _itemSlotTitleUI;

    private void OnDisable()
    {
        if (_itemSlotTitleUIInstance != null)
        {
            Destroy(_itemSlotTitleUIInstance);
        }
        Destroy(gameObject);
    }

    public void SetItemData(ItemData itemData)
    {
        _myItemData = itemData;
        transform.GetChild(0).GetComponent<Image>().sprite = _myItemData.GetItemSprite();
    }

    void Start()
    {
        _informationText = transform.parent.parent.Find("Information").GetChild(0).GetComponent<Text>();
    }

    public void OnMouseOver()
    {
        if (_itemSlotTitleUIInstance != null)
        {
            Destroy(_itemSlotTitleUIInstance);
        }

        _itemSlotTitleUIInstance = Instantiate(_itemSlotTitleUI, new Vector2(transform.position.x - 25f, transform.position.y - 25f), Quaternion.identity, transform.parent.parent);

        var itemSlotTitleText = _itemSlotTitleUIInstance.GetComponentInChildren<Text>();

        itemSlotTitleText.text = _myItemData.GetItemName();

        _informationText.text = _myItemData.GetItemInformation();
    }

    public void OnMouseExit()
    {
        if (_itemSlotTitleUIInstance != null)
        {
            _informationText.text = null;
            Destroy(_itemSlotTitleUIInstance);
        }
    }
}
