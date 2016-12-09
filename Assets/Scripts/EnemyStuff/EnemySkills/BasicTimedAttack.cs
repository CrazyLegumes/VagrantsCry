using UnityEngine;
using System.Collections;

public class BasicTimedAttack : Skills {



    public void Init(BaseEnemy me)
    {
        base.Init();
        ID = 2001;
        Name = "Elbow Smash";
        Cost = 0;
        Type = attacktype.Time;
        Desc = "A Crushing blow from the elbow! Press the indicated key at the right time to dodge!";
        Timer = 1;
        Bound = .05f;
        Damage = me.Stats.Strength * 2; 
    }

    public BasicTimedAttack(BaseEnemy me)
    {
        Init(me);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
