﻿using UnityEngine;
using System.Collections;

public class SelectMove : BattleState{

    private int option = 0;
    private bool canselect = false;
    private string[] sOption = { "Attack", "Skill", "Item", "Run" };
    public static string Option;

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());

    }

    public override void Exit()
    {
        base.Exit();
        StartCoroutine(Leave());
    }

    IEnumerator Init()
    {
        yield return null;
        controller.UI.EnableSelect();
        canselect = true;
        

    }

    IEnumerator Leave()
    {
        yield return null;
        canselect = false;
        controller.UI.DisableSelect();
    }


    protected override void ShiftUp()
    {
        base.ShiftUp();
        if (canselect)
            option--;
        if (option < 0)
            option = 3;
    }

    protected override void ShiftDown()
    {
        base.ShiftDown();
        if (canselect)
            option++;
        if (option > 3)
            option = 0;
    }


    protected override void Fire1()
    {
        base.Fire1();
        switch (Option)
        {
            case "Attack":
                controller.ChangeState<SelectTarget>();
                break;
            case "Skill":
                //controller.ChangeState<SelectSkill>();
                break;
            case "Item":
                //controller.ChangeState<SelectItem>();
                break;
            case "Run":

                //controller.ChangeState<RunAway>();
                break;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateOption();
        
	
	}


    void UpdateOption()
    {
        controller.UI.cursor.rectTransform.anchoredPosition = new Vector2(.5f, -1 - (53 * option));
        Option = sOption[option];
        

        
    }
}
