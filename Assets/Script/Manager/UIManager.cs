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

    private void Start()
    {
        _expSlider.value = ScoreManager.Instance.Exp;
        _coinText.text = ScoreManager.Instance.AllCoin.ToString();
    }
}
