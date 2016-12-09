using UnityEngine;
using System.Collections;

[System.Serializable]
public class GenericHoldAttack : Skills {

    public override void Init()
    {
        base.Init();
        ID = 1003;
        Name = "Charged Strike";
        Cost = 5;
        Type = attacktype.Hold;
        Desc = "A generic charged attack! Hold the indicated key until you see ! for maximum damage";
        Timer = 2;
        Damage = Mathf.CeilToInt(Player.Instance.Stats.Strength * 1.5f);
    }
}
