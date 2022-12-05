using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;

    [SerializeField]
    [Header("�G�l�~�[�f�[�^")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("�v���C���[���C�t�r���[")]
    PlayerView _playerView;

    [SerializeField]
    [Header("�G�l�~�[���C�t�r���[")]
    EnemyView _enemyView;

    void Start()
    {
        _playerData.Hp.Subscribe(life => _playerView.SetLife(life)).AddTo(this);
        _enemyData.Hp.Subscribe(life => _enemyView.SetLife(life)).AddTo(this);
    }
}
