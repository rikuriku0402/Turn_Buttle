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

    private void Start()
    {
        _expSlider.value = ScoreManager.Instance.Exp;
        _coinText.text = ScoreManager.Instance.AllCoin.ToString();
    }
}
