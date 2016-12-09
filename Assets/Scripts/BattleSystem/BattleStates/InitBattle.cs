using UnityEngine;
using System.Collections;

public class InitBattle : BattleState {

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].transform.position = enemyspawn[i].position;
            enemies[i].GetComponent<Mob>().Init();
            Debug.Log("Doot");
            yield return null;


        }
        Game.Instance.position = GameObject.Find("Player").transform.position;
        GameObject.Find("Player").transform.position = playerspawn.position;
        Game.Instance.state = GameState.InBattle;
        ui.EnableInfo();
        ui.EnableDesc();
        controller.ChangeState<SelectMove>();
        yield return null;



    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
