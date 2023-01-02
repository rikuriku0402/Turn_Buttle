using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    [Header("体力スライダー")]
    Slider _hpSlider;

    [SerializeField]
    [Header("攻撃ボタン")]
    Button _attackButton;

    [SerializeField]
    [Header("防御ボタン")]
    Button _defenceButton;

    [SerializeField]
    [Header("ログテキスト")]
    Text _logText;

    [SerializeField]
    [Header("プレイヤーHPテキスト")]
    Text _playerHpText;

    [SerializeField]
    [Header("バトルシステム")]
    Battle _battleSystem;

    private void Start()
    {
        _attackButton.onClick.AddListener(Attack);
        _defenceButton.onClick.AddListener(Defence);
    }

    async void Attack()
    {
        _attackButton.interactable = false;
        _defenceButton.interactable = false;
        _logText.text = "プレイヤーの攻撃";
        await _battleSystem.Attack();
        _logText.text = "Playerが敵に" +_battleSystem.AllDamage.ToString() + "与えた";
        _logText.text = "敵がPlayerに" + _battleSystem.AllDamage.ToString() + "与えた";
        _attackButton.interactable = true;
        _defenceButton.interactable = true;
    }

    async void Defence()
    {
        _attackButton.interactable = false;
        _defenceButton.interactable = false;
        _logText.text = "敵の攻撃";
        await _battleSystem.Defence();
        _logText.text = "防御した" + _battleSystem.AllDamage.ToString() + "くらった";
        _attackButton.interactable = true;
        _defenceButton.interactable = true;
    }

    public void SetLife(int lifeValue)
    {
        _hpSlider.value = lifeValue;
        _playerHpText.text = lifeValue.ToString() + _hpSlider.maxValue;
    }
}