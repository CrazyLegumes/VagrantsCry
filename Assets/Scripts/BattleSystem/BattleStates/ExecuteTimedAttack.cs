using UnityEngine;
using System.Collections;

public class ExecuteTimedAttack : BattleState
{
    private string[] option = { "Z", "X", "C" };
    private string Selected;
    private float timer;
    private float TimeReq;
    private bool canpress = false;
    private bool pressed;
    private int dmg = 0;
    private GameObject buttonUi;

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    public override void Exit()
    {
        base.Exit();
        if (buttonUi != null)
        {
            buttonUi.SetActive(false);
            buttonUi.GetComponentInChildren<Animator>().speed = 1;
        }
        target.cursor.gameObject.SetActive(false);
        buttonUi = null;
        timer = 0;
        
       
    }


    IEnumerator Init()
    {
        timer = 0;
        yield return null;
        canpress = true;
        int pick = (int)Random.Range(0f, 3f);
        if (pick == 3)
            pick = 2;

        TimeReq = selected.Timer;
        Selected = option[pick];
        pressed = false;
        Debug.Log(Selected);
        switch (Selected)
        {
            case "Z":
                buttonUi = GameObject.Find("BattleController/BattleUI/Buttons/ZTime");

                break;
            case "X":
                buttonUi = GameObject.Find("BattleController/BattleUI/Buttons/XTime");

                break;
            case "C":
                buttonUi = GameObject.Find("BattleController/BattleUI/Buttons/CTime");

                break;

        }

        if (buttonUi != null)
        {
            buttonUi.SetActive(true);
            buttonUi.GetComponentInChildren<Animator>().speed /= (TimeReq );
        }

        while (canpress)
        {
            
            timer += Time.deltaTime;
            yield return null;
            if ( !pressed && timer > TimeReq + (selected.Bound * 3.5))
            {
                Debug.Log("Missed");
               
                controller.ChangeState<EnemyCheck>();
                yield break;
            }
            if (pressed)
                break;

        }


    }


    protected override void Fire1()
    {
        pressed = true;

        if (Selected != option[0])
        {
            Debug.Log("Missed!");

            controller.ChangeState<SelectMove>();

        }

        else
        {
            DamageCalculation();
        }

    }




    protected override void Fire2()
    {
        pressed = true;

        if (Selected != option[1])
        {
            Debug.Log("Missed!");
            controller.ChangeState<EnemyCheck>();

        }

        else
        {
            DamageCalculation();
        }

    }

    protected override void Fire3()
    {
        pressed = true;

        if (Selected != option[2])
        {
            Debug.Log("Missed!");
            controller.ChangeState<EnemyCheck>();

        }

        else
        {
            DamageCalculation();
        }

    }

    void DamageCalculation()
    {
        //MaxDmg;
        if (timer > TimeReq - selected.Bound || timer < TimeReq + selected.Bound)
        {
            dmg = selected.Damage * 2;




        }

        //Normal Dmg
        if (timer < TimeReq - (selected.Bound *2) || timer > TimeReq + (selected.Bound * 2))
        {
            dmg = selected.Damage;
        }

        //ReducedDmg
        if (timer < TimeReq - (selected.Bound *3) || timer > TimeReq + (selected.Bound *3))
        {
            dmg = selected.Damage / 2;
        }
        dmg -= target.mobstats.Defense;
        if (dmg < 1)
            dmg = 1;
        target.DamageMe(dmg);
        Debug.Log("Did " + dmg + " to " + target.Owner.Name);
        Debug.Log(target.mobstats.Health);
        controller.ChangeState<EnemyCheck>();

    }


}
