using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleController : StateMachine {

    public List<Transform> enemyspawn;
    public Transform playerspawn;
    public List<GameObject> enemies = new List<GameObject>();
    public BattleUI UI;

   public void Init(GameObject obj)
    {
        List<GameObject> enemymobs = obj.GetComponent<BaseEnemy>().Mobs;
        obj.SetActive(false);
        CreateChar.StorePlayerInfo();
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
        Debug.Log(CurrentState);
	}
}
