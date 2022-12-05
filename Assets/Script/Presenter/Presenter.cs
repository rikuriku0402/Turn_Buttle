using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Presenter : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーデータ")]
    PlayerData _playerData;

    [SerializeField]
    [Header("エネミーデータ")]
    EnemyData _enemyData;

    [SerializeField]
    [Header("プレイヤーライフビュー")]
    PlayerView _playerView;

    [SerializeField]
    [Header("エネミーライフビュー")]
    EnemyView _enemyView;

    void Start()
    {
        _playerData.Hp.Subscribe(life => _playerView.SetLife(life)).AddTo(this);
        _enemyData.Hp.Subscribe(life => _enemyView.SetLife(life)).AddTo(this);
    }
}
