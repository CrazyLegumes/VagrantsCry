using UnityEngine;
using System.Collections;

public class BasicAttack : Skills
{



    public override void Init()
    {
        base.Init();
        ID = 1001;
        Name = "Basic Strike";
        Cost = 0;
        Type = attacktype.Time;
        Desc = "Your Basic attack! Time it right for extra damage";
        Timer = 1;
        Damage = Player.instance.Stats.Strength;
        Bound = .05f;
    }

    public BasicAttack() { }

}
