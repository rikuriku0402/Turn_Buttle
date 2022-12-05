using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    [Header("�̗̓X���C�_�[")]
    Slider _hpSlider;

    public void SetLife(int lifeValue)
    {
        _hpSlider.value = lifeValue;
    }
}
