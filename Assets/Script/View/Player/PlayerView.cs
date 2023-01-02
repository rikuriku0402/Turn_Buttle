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
    [Header("���O�e�L�X�g")]
    Text _logText;

    [SerializeField]
    [Header("�v���C���[HP�e�L�X�g")]
    Text _playerHpText;

    [SerializeField]
    [Header("�o�g���V�X�e��")]
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
        _logText.text = "�v���C���[�̍U��";
        await _battleSystem.Attack();
        _logText.text = "Player���G��" +_battleSystem.AllDamage.ToString() + "�^����";
        _logText.text = "�G��Player��" + _battleSystem.AllDamage.ToString() + "�^����";
        _attackButton.interactable = true;
        _defenceButton.interactable = true;
    }

    async void Defence()
    {
        _attackButton.interactable = false;
        _defenceButton.interactable = false;
        _logText.text = "�G�̍U��";
        await _battleSystem.Defence();
        _logText.text = "�h�䂵��" + _battleSystem.AllDamage.ToString() + "�������";
        _attackButton.interactable = true;
        _defenceButton.interactable = true;
    }

    public void SetLife(int lifeValue)
    {
        _hpSlider.value = lifeValue;
        _playerHpText.text = lifeValue.ToString() + _hpSlider.maxValue;
    }
}