using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーの体力")]
    int _playerHp;

    [SerializeField]
    [Header("敵の体力")]
    int _enemyHp;

    [SerializeField]
    [Header("攻撃ボタン")]
    Button _attackBtn;

    private void Start()
    {
        _attackBtn.onClick.AddListener(Attack);
    }

    void Attack()
    {
        print("攻撃した");
    }
}
