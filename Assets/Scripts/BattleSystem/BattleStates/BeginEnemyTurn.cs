using UnityEngine;
using System.Collections;

public class BeginEnemyTurn : BattleState{

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }


    IEnumerator Init()
    {
        attacker = null;
        yield return null;
        for(int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].GetComponent<Mob>().attacked)
            {
                attacker = enemies[i].GetComponent<Mob>();
                break;
            }
        }


        if (attacker != null)
            controller.ChangeState<DefendYourself>();

        if (attacker == null)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<Mob>().attacked = false;
            }
            controller.ChangeState<SelectMove>();
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
