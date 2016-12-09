using UnityEngine;
using System.Collections;

public class RunAway : BattleState{


    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return null;
        bool canescape = true;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].GetComponent<Mob>().mobstats.Speed > Player.Instance.Stats.Speed)
            {
                canescape = false;
                break;
            }
        }
        if (canescape)
        {
            yield return new WaitForSeconds(.1f);
            controller.ChangeState<EndBattle>();
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(.1f);
            controller.ChangeState<BeginEnemyTurn>();
        }

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
