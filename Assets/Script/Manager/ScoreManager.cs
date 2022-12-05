using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    public int AllCoin => _allCoin;

    public int Exp => _exp;

    int _allCoin;

    int _exp;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public int AddCoin(int coin)
    {
        _allCoin += coin;
        return _allCoin;
    }

    public int Decrease(int coin)
    {
        _allCoin -= coin;
        return _allCoin;
    }

    public int AddExp(int exp)
    {
        _exp += exp;
        return _exp;
    }
}
