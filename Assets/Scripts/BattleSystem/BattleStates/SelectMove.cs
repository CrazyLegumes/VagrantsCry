using UnityEngine;
using System.Collections;

public class SelectMove : BattleState
{

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
        option = 0;
        ui.EnableSelect();
        UpdateOption();
        yield return new WaitForSeconds(.5f);
        canselect = true;


    }

    IEnumerator Leave()
    {
        yield return null;
        canselect = false;

    }


    protected override void ShiftUp()
    {
        base.ShiftUp();
        if (canselect)
            option--;
        if (option < 0)
            option = 3;
        UpdateOption();
    }

    protected override void ShiftDown()
    {
        base.ShiftDown();
        if (canselect)
            option++;
        if (option > 3)
            option = 0;
        UpdateOption();
    }


    protected override void Fire1()
    {
        base.Fire1();
        switch (Option)
        {
            case "Attack":
                controller.ChangeState<SelectTarget>();
                selected = Player.Instance.basicattack;

                break;
            case "Skill":
                controller.ChangeState<SelectSkill>();

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }


    void UpdateOption()
    {
        ui.cursor.rectTransform.anchoredPosition = new Vector2(.5f, -1 - (53 * option));
        Option = sOption[option];
        switch (Option)
        {
            case "Attack":
                ui.Description.text = "Use your basic attacking ability! \n Attack Type: " + Player.Instance.basicattack.Type + "\n Damage: " + Player.Instance.basicattack.Damage;
                break;
            case "Skill":
                ui.Description.text = "Use one of your Acquired Skills!";
                break;
            case "Item":
                ui.Description.text = "Use an Item in your inventory! [Unimplemented]";
                break;
            case "Run":
                ui.Description.text = "Attempt to flee from the battle! \n Warning: Failing to flee will result in a loss of your turn!";
                break;
        }



    }
}
