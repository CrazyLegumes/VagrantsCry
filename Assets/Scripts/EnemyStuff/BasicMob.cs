using UnityEngine;
using System.Collections;

public class BasicMob : MonoBehaviour {

    [SerializeField]
    private BaseEnemy me;




	// Use this for initialization
	void Start () {

        me = new BaseEnemy();
        me.Name = "Mobu";
        
        
        me.Stats.Level = 1;
        me.Stats.Health = 10;
        me.Stats.MaxHealth = 10;
        me.Stats.Mana = 5;
        me.Stats.MaxMana = 5;
        me.Stats.Strength = 1;
        me.Stats.Defense = 0;
        me.Stats.Speed = 0;
        me.Stats.Luck = 0;
        me.EXPGiven = 20;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
