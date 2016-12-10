using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : StateMachine {

    public List<Transform> enemyspawn;
    public Transform playerspawn;
    public List<GameObject> enemies = new List<GameObject>();
    public BattleUI UI;
    public Skills selectedattack;
    public Mob target;
    public Mob attacker;
    public int expgain;
    public GameObject origenemy;


   public void Init(GameObject obj)
    {
        origenemy = obj;
        expgain = 0;
        List<GameObject> enemymobs = obj.GetComponent<BaseEnemy>().Mobs;
        obj.SetActive(false);
        CreateChar.StorePlayerInfo();
        enemies.Clear();
        for(int i = 0; i < enemymobs.Count; i++)
        {
            enemies.Add(EnemyPool.current.GetEnemies(enemymobs[i].GetComponent<Mob>().Owner.ID));
        }
        UI = FindObjectOfType<BattleUI>();

        ChangeState<InitBattle>();
    }

	// Use this for initialization
	void Start () {
        

        
	}
	
	// Update is called once per frame
	void Update () {

	}
}
