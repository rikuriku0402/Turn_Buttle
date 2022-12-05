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
        _defenceButton.interactable = false;
        _logText.text = "Player���G��" +_buttleSystem.PlayerAttack.ToString() + "�^����";
        await _buttleSystem.Attack();
        _logText.text = "�G��Player��" + _buttleSystem.EnemyAttack.ToString() + "�^����";
        _attackButton.interactable = true;
        _defenceButton.interactable = true;
    }

    async void Defence()
    {
        _attackButton.interactable = false;
        _defenceButton.interactable = false;
        _logText.text = "�h�䂵��" + _buttleSystem.EnemyAttack.ToString() + "�������";
        await _buttleSystem.Defence();
        _attackButton.interactable = true;
        _defenceButton.interactable = true;
    }

    public void SetLife(int lifeValue)
    {
        _hpSlider.value = lifeValue;
    }
}