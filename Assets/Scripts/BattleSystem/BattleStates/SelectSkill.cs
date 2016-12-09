using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectSkill :BattleState {
    private int option;
    private bool canselect;
    private List<Skills> available;



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
        option = 0;
        canselect = true;
        ui.EnableSkill();
        available = Player.Instance.Skills;
        UpdateOption();
        ui.cursor.rectTransform.localScale = new Vector3(1.5f, 1, 1);
        yield return null;
    }

    IEnumerator DeInit()
    {
        canselect = false;
        ui.DisableSkill();
        ui.cursor.rectTransform.localScale = new Vector3(1, 1, 1);
        yield return null;
    }

    protected override void ShiftUp()
    {
        base.ShiftUp();
        option--;
        if (option < 0)
            option = available.Count - 1;
        UpdateOption();
    }

    protected override void ShiftDown()
    {
        base.ShiftDown();
        option++;
        if (option > available.Count - 1)
            option = 0;
        UpdateOption();
    }


    protected override void Fire1()
    {

        base.Fire1();
        controller.ChangeState<SelectTarget>(); 
    }


    protected override void Fire2()
    {
        base.Fire2();
        controller.ChangeState<SelectMove>();
    }
    // Use this for initialization
    void Start () {
	
	}

    void UpdateOption()
    {
        selected = available[option];
        ui.cursor.rectTransform.anchoredPosition = new Vector2(133.5f, -1 - (53 * option));
        ui.Description.text = "" + selected.Name + ": " + selected.Desc + "\n Attack Type: " + selected.Type + "\n Damage: " + selected.Damage + "\n Mana Cost: " +
             selected.Cost + "\n Time: " + selected.Timer;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(ui.cursor.rectTransform.anchoredPosition);
	
	}
}
