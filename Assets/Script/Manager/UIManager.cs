using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    int count = 0;

    ItemType _type;

    #region Inspecter

    [SerializeField]
    [Header("�U���̓A�b�v�{�^��")]
    List<ItemButton> _itemButton;

    [SerializeField]
    [Header("�o���l�X���C�_�[")]
    Slider _expSlider;

    [SerializeField]
    [Header("�R�C���e�L�X�g")]
    Text _coinText;

    [SerializeField]
    [Header("�V���b�v�C���[�W")]
    Image _shopImage;

    [SerializeField]
    [Header("�C���x���g���C���[�W")]
    Image _inventoryImage;

    [SerializeField]
    [Header("�A�C�e���C���[�W")]
    List<Image> _items;

    [SerializeField]
    [Header("�A�C�e���{�b�N�X")]
    GameObject _itemBox;

    [SerializeField]
    [Header("�񕜂��̂�")]
    Button _mushroomButton;

    [SerializeField]
    [Header("�V���b�v�J����{�^��")]
    Button _shopOpenButton;

    [SerializeField]
    [Header("�C���x���g���m�F�{�^��")]
    Button _inventoryButton;

    [SerializeField]
    Button _testButton;

    [SerializeField]
    GameObject _testObj;

    #endregion

    enum ItemType
    {
        Large,
        Medium,
        Small
    }

    private void Start()
    {
        _expSlider.value = ScoreManager.Instance.Exp;
        _coinText.text = ScoreManager.Instance.AllCoin.ToString();
        _mushroomButton.onClick.AddListener(() => BuyItem(ShopManager.Instance.ItemPrices[0].Price));
        //_itemButton[0].Buttons.onClick.AddListener(() => BuyItem(ShopManager.Instance.ItemPrices[1].Price));
        //_itemButton[1].Buttons.onClick.AddListener(() => BuyItem(ShopManager.Instance.ItemPrices[2].Price));
        //_itemButton[2].Buttons.onClick.AddListener(() => BuyItem(ShopManager.Instance.ItemPrices[3].Price));
        for (int i = 0; i < _itemButton.Count; i++)
        {
            print(i);
            _itemButton[i].Buttons.onClick.AddListener(() => BuyItem(ShopManager.Instance.ItemPrices[i].Price));
        }
        _shopOpenButton.onClick.AddListener(() => ImageOpen(_shopImage));
        _inventoryButton.onClick.AddListener(() => ImageOpen(_inventoryImage));

        _testButton.onClick.AddListener(() => TestImageOpen(_testObj));
    }

    void BuyItem(int price)
    {
        if (ScoreManager.Instance.AllCoin >= price)
        {
            print("�����܂���");
            ScoreManager.Instance.Decrease(price);
            _coinText.text = ScoreManager.Instance.AllCoin.ToString();
            var obj = Instantiate(_items[(int)_type], transform.position, Quaternion.identity);
            obj.transform.SetParent(_itemBox.transform, false);
        }
        else
        {
            print("����ˁ[��΁[��");
        }
    }

    void ImageOpen(Image image)
    {
        switch (count)
        {
            case 0:
                image.gameObject.SetActive(true);
                break;
            case 1:
                image.gameObject.SetActive(false);
                break;
        }
        count++;
        if (count == 2) count = 0;
    }
    void TestImageOpen(GameObject image)
    {
        switch (count)
        {
            case 0:
                image.gameObject.SetActive(true);
                break;
            case 1:
                image.gameObject.SetActive(false);
                break;
        }
        count++;
        if (count == 2) count = 0;
    }
}

[System.Serializable]
public class ItemButton
{
    public Button Buttons => _buttons;

    public string Explanation => _explanation;

    [SerializeField]
    string _explanation;

    [SerializeField]
    Button _buttons;
}