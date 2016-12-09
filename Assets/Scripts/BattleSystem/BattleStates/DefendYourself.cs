using UnityEngine;
using System.Collections;

public class DefendYourself : BattleState
{
    private Skills used;
    private string[] option = { "Z", "X", "C" };
    private int hitsneeded;
    private int hitsgot;
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
    }

    IEnumerator Init()
    {
        yield return null;
        attacker.attacked = true;
        dmg = 0;
        timer = 0;
        used = attacker.GetSkillFromList();
        TimeReq = used.Timer;
        int pick = Random.Range(0, 3);
        Selected = option[pick];
        switch (used.Type)
        {
            case attacktype.Time:
                StartCoroutine(Dodge());
                break;

            case attacktype.Spam:
                StartCoroutine(Reflect());
                break;
        }



    }



    IEnumerator Dodge()
    {
        canpress = true;
        yield return null;
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
            buttonUi.GetComponentInChildren<Animator>().speed /= (TimeReq);
        }
        while (canpress)
        {
            timer += Time.deltaTime;
            if (!pressed && timer > TimeReq + (used.Bound * 3.5f))
            {
                dmg = used.Damage;
                Player.Instance.DamageMe(dmg);
                Debug.Log("Hit for " + dmg + " damage");
                controller.ChangeState<PlayerCheck>();
            }
            if (pressed)
                break;
        }






    }

    IEnumerator Reflect()
    {
        yield return null;
    }





    protected override void Fire1()
    {
        if (Selected != option[0])
        {
            dmg = used.Damage;
            Player.Instance.DamageMe(dmg);
            Debug.Log("Hit for " + dmg + " damage");
            controller.ChangeState<PlayerCheck>();
        }
        switch (used.Type)
        {
            case attacktype.Spam:
                break;
            case attacktype.Time:
                CheckDodge();
                break;
        }
    }
    protected override void Fire2()
    {
        if (Selected != option[1])
        {
            dmg = used.Damage;
            Player.Instance.DamageMe(dmg);
            Debug.Log("Hit for " + dmg + " damage");
            controller.ChangeState<PlayerCheck>();
        }
        switch (used.Type)
        {
            case attacktype.Spam:
                break;
            case attacktype.Time:
                CheckDodge();
                break;
        }
    }
    protected override void Fire3()
    {
        if (Selected != option[2])
        {
            dmg = used.Damage;
            Player.Instance.DamageMe(dmg);
            Debug.Log("Hit for " + dmg + " damage");
            controller.ChangeState<PlayerCheck>();
        }
        switch (used.Type)
        {
            case attacktype.Spam:

                break;
            case attacktype.Time:
                CheckDodge();
                break;
        }
    }



    void CheckDodge()
    {

        //Dodged
        if (timer > TimeReq - selected.Bound || timer < TimeReq + selected.Bound)
        {
            dmg = 0;




        }

        //Blocked
        if (timer < TimeReq - (selected.Bound * 2) || timer > TimeReq + (selected.Bound * 2))
        {
            dmg = used.Damage - Player.Instance.Stats.Defense;
        }

        //Partial Block
        if (timer < TimeReq - (selected.Bound * 3) || timer > TimeReq + (selected.Bound * 3))
        {
            dmg = used.Damage - Player.Instance.Stats.Defense / 2;

        }

        if (dmg < 0)
            dmg = 0;


        Player.Instance.DamageMe(dmg);

        Debug.Log("Did " + dmg + " to " + Player.Instance.Name);

        controller.ChangeState<PlayerCheck>();
    }


}
