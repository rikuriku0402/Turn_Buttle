using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class Battle : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;

    [SerializeField]
    [Header("エネミーデータ")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("プレイヤーの攻撃力")]
    int _playerAttack;

    [SerializeField]
    [Header("敵の攻撃力")]
    int _enemyAttack;

    public async UniTask Attack()
    {
        print("敵に攻撃");
        _enemyData.Damage(_playerAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        print("敵のターン");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.Damage(_enemyAttack);
        HpCheck();
    }

    public async UniTask Defence()
    {
        int allAttack = _enemyAttack - 10;
        print("防御");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        print("敵のターン");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.Damage(allAttack);
        HpCheck();
    }

    void HpCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            print("ゲームオーバー");
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            print("ゲームクリア");
        }
    }
}
