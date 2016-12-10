using UnityEngine;
using System.Collections;

public class EndBattle : BattleState {

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return null;
        CreateChar.StorePlayerInfo();
        Game.instance.state = GameState.InWorld;
        controller.CurrentState = null;
        ui.DisableDesc();
        ui.DisableInfo();
        ui.DisableSkill();
        ui.DisableSelect();
        if (enemies.Count == 0)
            Destroy(controller.origenemy);
        else
        {
            for(int i =0; i < enemies.Count; i++)
            {
                enemies[i].SetActive(false);
                
            }
            controller.origenemy.SetActive(true);
           
        }
        GameObject.Find("Player").transform.position = Game.instance.position - new Vector3(3,0,0);
        yield break;
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
