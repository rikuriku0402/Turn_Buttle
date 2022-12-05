using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System;

public class Battle : MonoBehaviour
{
    public int EnemyAttack => _enemyAttack;

    public int PlayerAttack => _playerAttack;

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
    [Header("�Q�b�g�R�C����")]
    int _dropCoin;

    [SerializeField]
    [Header("���炷�R�C����")]
    int _decreaseCoin;

    [SerializeField]
    [Header("�Q�b�g�o���l")]
    int _getExp;

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
