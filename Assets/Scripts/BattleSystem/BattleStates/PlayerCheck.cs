using UnityEngine;
using System.Collections;

public class PlayerCheck : BattleState
{


    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }


    IEnumerator Init()
    {
        bool myturn = true;
        if (Player.instance.Stats.Health == 0)
        {
            Debug.Log("Player is Dead");
            yield break;
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].GetComponent<Mob>().attacked)
            {
                myturn = false;
                Debug.Log("Still not your turn");
                break;
            }
        }
        if (myturn)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].GetComponent<Mob>().attacked = false;
            }
            yield return new WaitForSeconds(.1f);
            controller.ChangeState<SelectMove>();
            yield break;

        }
        else {
            Debug.Log("Starting EnemyTurn Again");
            yield return new WaitForSeconds(.1f);
            controller.ChangeState<BeginEnemyTurn>();
            yield break;
        }

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
