using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class Buttle : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;

    [SerializeField]
    [Header("�U���{�^��")]
    Button _attackBtn;

    [SerializeField]
    [Header("�U����")]
    int _attack;

    private void Start()
    {
        _attackBtn.onClick.AddListener(Attack);
    }

    void Attack()
    {
        print("�G�ɍU��");
        _attackBtn.interactable = false;
        _playerData.Damage(_attack);
        var task = WaitTime();
    }

    async UniTask WaitTime()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        print("�G�̃^�[��");
        _attackBtn.interactable = true;
    }
}
