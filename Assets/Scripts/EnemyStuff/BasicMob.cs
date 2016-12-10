using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicMob : BaseEnemy
{

    [SerializeField]
    private BaseEnemy me;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && Game.instance.state == GameState.InWorld)
            FindObjectOfType<BattleController>().Init(gameObject);
        

    }

    public override void Init()
    {
        
        me = GetComponent<BasicMob>();
        me.Name = "Mobu";
        me.ID = 1001;
        me.Stats.Level = 1;
        me.Stats.Health = 10;
        me.Stats.MaxHealth = 10;
        me.Stats.Mana = 5;
        me.Stats.MaxMana = 5;
        me.Stats.Strength = 3;
        me.Stats.Defense = 0;
        me.Stats.Speed = 0;
        me.Stats.Luck = 0;
        me.EXPGiven = 20;
        me.enemySkills.Add(new BasicTimedAttack(me));
        base.Init();

    }
    // Use this for initialization
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
