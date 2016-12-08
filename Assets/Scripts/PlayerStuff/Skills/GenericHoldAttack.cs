using UnityEngine;
using System.Collections;

[System.Serializable]
public class GenericHoldAttack : Skills {

    public override void Init()
    {
        base.Init();
        ID = 1003;
        Cost = 5;
        Type = attacktype.Hold;
        Desc = "A generic charged attack! Hold the indicated key until you see ! for maximum damage";
        Timer = 2;
    }
}
