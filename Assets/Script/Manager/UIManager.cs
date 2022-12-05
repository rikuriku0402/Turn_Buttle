using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    [Header("経験値スライダー")]
    Slider _expSlider;

    [SerializeField]
    [Header("コインテキスト")]
    Text _coinText;

    [SerializeField]
    [Header("回復きのこ")]
    Button _mushroomButton;

    private void Start()
    {
        _expSlider.value = ScoreManager.Instance.Exp;
        _coinText.text = ScoreManager.Instance.AllCoin.ToString();
        _mushroomButton.onClick.AddListener(() => BuyMushroom(10));
    }

    void BuyMushroom(int price)
    {
        if (ScoreManager.Instance.AllCoin >= price)
        {
            print("買えました");
            ScoreManager.Instance.Decrease(price);
            _coinText.text = ScoreManager.Instance.AllCoin.ToString();
        }
    }
}
