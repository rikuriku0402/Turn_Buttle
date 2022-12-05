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
    [Header("バトルシステム")]
    Battle _buttleSystem;

    private void Start()
    {
        _attackButton.onClick.AddListener(Attack);
        _defenceButton.onClick.AddListener(Defence);
    }

    async void Attack()
    {
        _attackButton.interactable = false;
        await _buttleSystem.Attack();
        _attackButton.interactable = true;
    }

    async void Defence()
    {
        _defenceButton.interactable = false;
        await _buttleSystem.Defence();
        _defenceButton.interactable = true;
    }

    public void SetLife(int lifeValue)
    {
        _hpSlider.value = lifeValue;
    }
}
