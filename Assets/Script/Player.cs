using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�̗̑�")]
    int _playerHp;

    [SerializeField]
    [Header("�G�̗̑�")]
    int _enemyHp;

    [SerializeField]
    [Header("�U���{�^��")]
    Button _attackBtn;

    private void Start()
    {
        _attackBtn.onClick.AddListener(Attack);
    }

    void Attack()
    {
        print("�U������");
    }
}
