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
    [Header("攻撃力アップボタン")]
    List<ItemButton> _itemButton;

    [SerializeField]
    [Header("経験値スライダー")]
    Slider _expSlider;

    [SerializeField]
    [Header("コインテキスト")]
    Text _coinText;

    [SerializeField]
    [Header("ショップイメージ")]
    Image _shopImage;

    [SerializeField]
    [Header("インベントリイメージ")]
    Image _inventoryImage;

    [SerializeField]
    [Header("アイテムイメージ")]
    List<Image> _items;

    [SerializeField]
    [Header("アイテムボックス")]
    GameObject _itemBox;

    [SerializeField]
    [Header("回復きのこ")]
    Button _mushroomButton;

    [SerializeField]
    [Header("ショップ開けるボタン")]
    Button _shopOpenButton;

    [SerializeField]
    [Header("インベントリ確認ボタン")]
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
            print("買えました");
            ScoreManager.Instance.Decrease(price);
            _coinText.text = ScoreManager.Instance.AllCoin.ToString();
            var obj = Instantiate(_items[(int)_type], transform.position, Quaternion.identity);
            obj.transform.SetParent(_itemBox.transform, false);
        }
        else
        {
            print("たりねーよばーか");
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