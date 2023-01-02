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

    [SerializeField]
    [Header("プレイヤーの防御力")]
    int _playerDefence;

    [SerializeField]
    [Header("敵の防御力")]
    int _enemyDefence;

    [SerializeField]
    [Header("ゲットコイン数")]
    int _dropCoin;

    [SerializeField]
    [Header("減らすコイン数")]
    int _decreaseCoin;

    [SerializeField]
    [Header("ゲット経験値")]
    int _getExp;

    private int _allDamage;

    public async UniTask Attack()
    {
        print("敵に攻撃");
        _allDamage = _playerAttack - _enemyDefence;
        _enemyData.Damage(_playerAttack);
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        print("敵のターン");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.Damage(_allDamage);
        HpCheck();
    }

    public async UniTask Defence()
    {
        _allDamage = _playerAttack / _enemyDefence;
        print(_allDamage);
        print("防御");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        print("敵のターン");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        _playerData.Damage(_allDamage);
        HpCheck();
    }

    void HpCheck()
    {
        if (_playerData.Hp.Value <= 0)
        {
            print("ゲームオーバー");
            _decreaseCoin = UnityEngine.Random.Range(25, 50);
            ScoreManager.Instance.Decrease(_decreaseCoin);
        }
        else if (_enemyData.Hp.Value <= 0)
        {
            print("ゲームクリア");
            _dropCoin = UnityEngine.Random.Range(25, 50);
            ScoreManager.Instance.AddCoin(_dropCoin);
            ScoreManager.Instance.AddExp(_getExp);
            SceneManager.LoadSceneAsync("Map");
        }
    }
}
