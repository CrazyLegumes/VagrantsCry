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
                Debug.Log(attacker.gameObject.name);
                enemies[i].GetComponent<Mob>().attacked = true;
                break;
            }
        }


        if (attacker != null)
        {
            yield return new WaitForSeconds(2f);
            
            controller.ChangeState<DefendYourself>();
            yield break;
        }

        if (attacker == null)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<Mob>().attacked = false;
            }
            controller.ChangeState<SelectMove>();
            yield break;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
