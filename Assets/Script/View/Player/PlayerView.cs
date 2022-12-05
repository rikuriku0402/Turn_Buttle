using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    [Header("�̗̓X���C�_�[")]
    Slider _hpSlider;

    [SerializeField]
    [Header("�U���{�^��")]
    Button _attackButton;

    [SerializeField]
    [Header("�h��{�^��")]
    Button _defenceButton;

    [SerializeField]
    [Header("�o�g���V�X�e��")]
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
