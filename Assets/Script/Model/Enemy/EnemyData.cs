using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyData : MonoBehaviour
{
    public IntReactiveProperty Hp => _hp;

    [SerializeField]
    [Header("“G‚Ì‘Ì—Í")]
    IntReactiveProperty _hp = new IntReactiveProperty(120);

    private void OnDestroy()
    {
        Hp.Dispose();
    }

    public void Damage(int value)
    {
        Hp.Value -= value;
    }
}
