using UnityEngine;
using System.Collections;

[System.Serializable]
public class GenericSpamAttack : Skills {



    public override void Init()
    {
        base.Init();
        ID = 1002;
        Name = "Furry of Blows";
        Cost = 10;
        Type = attacktype.Spam;
        Desc = "A Generic flurry of attacks! Press the indicated key as fast as possible!";
        Timer = 1;
        Damage = Player.instance.Stats.Strength / 2;

    }
    
}
