using UnityEngine;
using System.Collections;

public class EnemyCheck : BattleState
{



    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }


    public override void Exit()
    {
        base.Exit();
        StartCoroutine(DeInit());
    }



    IEnumerator Init()
    {

        for (int i = 0; i < enemies.Count; i++)
        {
            GameObject obj = enemies[i];
            if (obj.GetComponent<Mob>().dead)
            {
                obj.GetComponent<Mob>().Fade();
                yield return new WaitForSeconds(1);
                expgain += obj.GetComponent<Mob>().expgiven;
                enemies[i].SetActive(false);
                enemies.Remove(enemies[i]);

            }
            yield return null;

            if (enemies.Count == 0)
            {
                Debug.Log("All Enemies Are Dead");
                controller.ChangeState<Win>();
                yield break;
            }
            else
                controller.ChangeState<BeginEnemyTurn>();

        }
    }

    IEnumerator DeInit()
    {
        yield return null;
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
