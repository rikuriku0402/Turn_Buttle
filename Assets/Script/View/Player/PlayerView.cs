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
        _logText.text = "Playerが敵に" +_battleSystem.PlayerAttack.ToString() + "与えた";
        await _battleSystem.Attack();
        _logText.text = "敵がPlayerに" + _battleSystem.EnemyAttack.ToString() + "与えた";
        _attackButton.interactable = true;
        _defenceButton.interactable = true;
    }

    async void Defence()
    {
        _attackButton.interactable = false;
        _defenceButton.interactable = false;
        _logText.text = "防御した" + _battleSystem.EnemyAttack.ToString() + "くらった";
        await _battleSystem.Defence();
        _attackButton.interactable = true;
        _defenceButton.interactable = true;
    }

    public void SetLife(int lifeValue)
    {
        _hpSlider.value = lifeValue;
    }
}