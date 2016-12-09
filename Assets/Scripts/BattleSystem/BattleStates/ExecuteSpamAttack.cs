using UnityEngine;
using System.Collections;

public class ExecuteSpamAttack : BattleState
{

    private string[] option = { "Z", "X", "C" };
    private string Selected;
    private float timer;
    private float TimeReq;
    private bool canpress = false;
    private int dmg;
    private GameObject buttonUi;


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
        yield return null;
        timer = 0;
        dmg = 0;
        yield return null;
        
        int pick = (int)Random.Range(0f, 3f);
        if (pick == 3)
            pick = 2;

        TimeReq = selected.Timer;
        Selected = option[pick];

        Debug.Log(Selected);
        switch (Selected)
        {
            case "Z":
                buttonUi = GameObject.Find("BattleController/BattleUI/Buttons/ZSpam");

                break;
            case "X":
                buttonUi = GameObject.Find("BattleController/BattleUI/Buttons/XSpam");

                break;
            case "C":
                buttonUi = GameObject.Find("BattleController/BattleUI/Buttons/CSpam");

                break;

        }


        if (buttonUi != null)
        {
            buttonUi.SetActive(true);

        }
        yield return new WaitForSeconds(.5f);
        canpress = true;


        while (canpress)
        {

            timer += Time.deltaTime;
            yield return null;
            if (timer > TimeReq)
            {
                target.DamageMe(dmg);
                Debug.Log("Target took a total of " + dmg + " Damage!");
                Debug.Log(target.mobstats.Health);

                if (buttonUi != null)
                    buttonUi.SetActive(false);
                yield return new WaitForSeconds(1f);

                controller.ChangeState<EnemyCheck>();
                yield break;
            }

        }
    }

    IEnumerator DeInit()
    {
        yield return null;
        canpress = false;
        target.cursor.gameObject.SetActive(false);
        buttonUi = null;
        timer = 0;
    }


    protected override void Fire1()
    {

        base.Fire1();
        if (canpress)
        {
            if (Selected != option[0])
                Debug.Log("Miss");
            else
                IncrementDamage();
        }
    }

    protected override void Fire2()
    {
        base.Fire2();
        if (canpress)
        {
            if (Selected != option[1])
                Debug.Log("Miss");
            else
                IncrementDamage();
        }
    }

    protected override void Fire3()
    {
        base.Fire3();
        if (canpress)
        {
            if (Selected != option[2])
                Debug.Log("Miss");
            else
                IncrementDamage();
        }
    }


    private void IncrementDamage()
    {
        int dam = selected.Damage - target.mobstats.Defense;
        if (dam < 1)
            dam = 1;
        dmg += dam;

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
