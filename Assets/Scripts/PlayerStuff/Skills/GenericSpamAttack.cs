using UnityEngine;
using System.Collections;

[System.Serializable]
public class GenericSpamAttack : Skills {



    public override void Init()
    {
        base.Init();
        ID = 1002;
        Cost = 10;
        Type = attacktype.Spam;
        Desc = "A Generic flurry of attacks! Press the indicated key as fast as possible!";
        Timer = 1;
    }
    
}
