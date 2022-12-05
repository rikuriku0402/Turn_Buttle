using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class Buttle : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;

    [SerializeField]
    [Header("攻撃ボタン")]
    Button _attackBtn;

    [SerializeField]
    [Header("攻撃力")]
    int _attack;

    private void Start()
    {
        _attackBtn.onClick.AddListener(Attack);
    }

    void Attack()
    {
        print("敵に攻撃");
        _attackBtn.interactable = false;
        _playerData.Damage(_attack);
        var task = WaitTime();
    }

    async UniTask WaitTime()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        print("敵のターン");
        _attackBtn.interactable = true;
    }
}
