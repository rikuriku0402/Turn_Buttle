using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerData : MonoBehaviour
{
    public IntReactiveProperty Hp => _hp;

    [SerializeField]
    [Header("ƒvƒŒƒCƒ„[‚Ì‘Ì—Í")]
    IntReactiveProperty _hp = new IntReactiveProperty(100);

    private void OnDestroy()
    {
        Hp.Dispose();
    }

    public void Damage(int value)
    {
        Hp.Value -= value;
    }

    public void Defence(int value)
    {
        Hp.Value -= value;
    }

}
