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
    [Header("ライフビュー")]
    LifeView _lifeView;

    void Start()
    {
        _playerData.Hp.Subscribe(life => _lifeView.SetLife(life)).AddTo(this);
    }
}
