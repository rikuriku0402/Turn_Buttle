using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;

public class Battle : MonoBehaviour
{
    public int EnemyAttack => _enemyAttack;

    public int PlayerAttack => _playerAttack;

    public int AllDamage => _allDamage;

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

    [SerializeField]
    [Header("�v���C���[�̖h���")]
    int _playerDefence;

    [SerializeField]
    [Header("�G�̖h���")]
    int _enemyDefence;

    [SerializeField]
    [Header("�Q�b�g�R�C����")]
    int _dropCoin;

    [SerializeField]
    [Header("���炷�R�C����")]
    int _decreaseCoin;

    [SerializeField]
    [Header("�Q�b�g�o���l")]
    int _getExp;

    private int _allDamage;

    public async UniTask Attack()
    {
        print("�G�ɍU��");
        _allDamage = _playerAttack - _enemyDefence;
        _enemyData.Damage(_playerAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        print("�G�̃^�[��");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.Damage(_allDamage);
        HpCheck();
    }

    public async UniTask Defence()
    {
        _allDamage = _playerAttack / _enemyDefence;
        print(_allDamage);
        print("�h��");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        print("�G�̃^�[��");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.Damage(_allDamage);
        HpCheck();
    }

    void HpCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            print("�Q�[���I�[�o�[");
            _decreaseCoin = UnityEngine.Random.Range(25, 50);
            ScoreManager.Instance.Decrease(_decreaseCoin);
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            print("�Q�[���N���A");
            _dropCoin = UnityEngine.Random.Range(25, 50);
            ScoreManager.Instance.AddCoin(_dropCoin);
            ScoreManager.Instance.AddExp(_getExp);
            SceneManager.LoadSceneAsync("Map");
        }
    }
}
