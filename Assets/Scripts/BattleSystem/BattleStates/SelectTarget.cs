using UnityEngine;
using System.Collections;

public class SelectTarget : BattleState
{
    private int option = 0;
    private bool canselect = false;



    public override void Enter()
    {
        base.Enter();
        canselect = false;

        StartCoroutine(Init());
    }

    public override void Exit()
    {
        base.Exit();
        option = 0;
        canselect = false;
        StartCoroutine(DeInit());
    }



    IEnumerator Init()
    {

        yield return null;
        option = 0;

        enemies[option].GetComponent<Mob>().cursor.gameObject.SetActive(true);
        UpdateTarget();
        canselect = true;

    }

    IEnumerator DeInit()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].gameObject != target.gameObject)
                enemies[i].GetComponent<Mob>().cursor.gameObject.SetActive(false);
        }
        yield return null;
    }

    protected override void ShiftUp()
    {
        base.ShiftUp();
        if (canselect)
        {
            enemies[option].GetComponent<Mob>().cursor.gameObject.SetActive(false);
            option--;
            if (option < 0)
                option = enemies.Count - 1;
            enemies[option].GetComponent<Mob>().cursor.gameObject.SetActive(true);
        }
        UpdateTarget();

    }

    protected override void ShiftDown()
    {
        base.ShiftDown();
        if (canselect)
        {
            enemies[option].GetComponent<Mob>().cursor.gameObject.SetActive(false);
            option++;
            if (option > enemies.Count - 1)
                option = 0;
            enemies[option].GetComponent<Mob>().cursor.gameObject.SetActive(true);
        }
        UpdateTarget();

    }

    protected override void Fire2()
    {
        base.Fire2();
        controller.ChangeState<SelectMove>();
    }



    protected override void Fire1()
    {
        base.Fire1();
        switch (selected.Type)
        {
            case attacktype.Time:
                controller.ChangeState<ExecuteTimedAttack>();
                break;
            case attacktype.Spam:
                //controller.ChangeState<ExecuteSpamAtack>();
                break;
            case attacktype.Hold:
                //controller.ChangeState<ExecuteHoldAttack>();
                break;
        }
    }


    void UpdateTarget()
    {
        target = enemies[option].GetComponent<Mob>().Owner;

    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(selected.Name);

    }
}
