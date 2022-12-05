using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    [Header("�o���l�X���C�_�[")]
    Slider _expSlider;

    [SerializeField]
    [Header("�R�C���e�L�X�g")]
    Text _coinText;

    [SerializeField]
    [Header("�񕜂��̂�")]
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
            print("�����܂���");
            ScoreManager.Instance.Decrease(price);
            _coinText.text = ScoreManager.Instance.AllCoin.ToString();
        }
    }
}
