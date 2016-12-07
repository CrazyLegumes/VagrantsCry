using UnityEngine;
using System.Collections;

public class BasicMob : BaseEnemy {

    [SerializeField]
    private BaseEnemy me;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && Game.Instance.state == GameState.InWorld)
            FindObjectOfType<BattleController>().Init(gameObject);
           

    }
	// Use this for initialization
	void Awake () {

        me = GetComponent<BasicMob>();
        me.Name = "Mobu";

        me.ID = 1001;
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
