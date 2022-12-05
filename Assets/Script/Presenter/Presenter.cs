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
    [Header("���C�t�r���[")]
    LifeView _lifeView;

    void Start()
    {
        _playerData.Hp.Subscribe(life => _lifeView.SetLife(life)).AddTo(this);
    }
}
