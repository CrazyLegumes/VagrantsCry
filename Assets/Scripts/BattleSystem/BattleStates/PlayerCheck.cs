using UnityEngine;
using System.Collections;

public class PlayerCheck : BattleState{


    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }


    IEnumerator Init()
    {
        bool myturn = true;
        if (Player.Instance.Stats.Health == 0) {
            Debug.Log("Player is Dead");
            yield break;
        }

        else
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].GetComponent<Mob>().attacked)
                {
                    myturn = false;
                    break;
                }
            }
            if (myturn)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].GetComponent<Mob>().attacked = false;
                }
                controller.ChangeState<SelectMove>();
                
            }
            else
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
