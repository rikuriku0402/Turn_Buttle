using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class Battle : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;

    [SerializeField]
    [Header("�G�l�~�[�f�[�^")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("�v���C���[�̍U����")]
    int _playerAttack;

    [SerializeField]
    [Header("�G�̍U����")]
    int _enemyAttack;

    public async UniTask Attack()
    {
        print("�G�ɍU��");
        _enemyData.Damage(_playerAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        print("�G�̃^�[��");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.Damage(_enemyAttack);
        HpCheck();
    }

    public async UniTask Defence()
    {
        int allAttack = _enemyAttack - 10;
        print("�h��");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        print("�G�̃^�[��");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.Damage(allAttack);
        HpCheck();
    }

    void HpCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            print("�Q�[���I�[�o�[");
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            print("�Q�[���N���A");
        }
    }
}
