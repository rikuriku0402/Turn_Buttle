using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    [Header("体力スライダー")]
    Slider _hpSlider;

    public void SetLife(int lifeValue)
    {
        _hpSlider.value = lifeValue;
    }
}
