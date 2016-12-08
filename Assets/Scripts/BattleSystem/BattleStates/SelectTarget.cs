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

            controller.enemies[option].GetComponent<BaseEnemy>().Cursor.gameObject.SetActive(true);
        canselect = true;

    }

    IEnumerator DeInit()
    {
        for(int i= 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<BaseEnemy>().Cursor.gameObject.SetActive(false);
        }
        yield return null;
    }

    protected override void ShiftUp()
    {
        base.ShiftUp();
        if (canselect)
        {
            controller.enemies[option].GetComponent<BaseEnemy>().Cursor.gameObject.SetActive(false);
            option--;
            if (option < 0)
                option = enemies.Count - 1;
            controller.enemies[option].GetComponent<BaseEnemy>().Cursor.gameObject.SetActive(true);
        }

    }

    protected override void ShiftDown()
    {
        base.ShiftDown();
        if (canselect)
        {
            controller.enemies[option].GetComponent<BaseEnemy>().Cursor.gameObject.SetActive(false);
            option++;
            if (option > enemies.Count - 1)
                option = 0;
            controller.enemies[option].GetComponent<BaseEnemy>().Cursor.gameObject.SetActive(true);
        }

    }

    protected override void Fire2()
    {
        base.Fire2();
        controller.ChangeState<SelectMove>();
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
