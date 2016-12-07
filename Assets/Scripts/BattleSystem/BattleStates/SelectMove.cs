using UnityEngine;
using System.Collections;

public class SelectMove : BattleState{

    public int option = 0;
    bool canselect = false;

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());

    }

    IEnumerator Init()
    {
        yield return null;
        controller.UI.EnableSelect();
        canselect = true;

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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        controller.UI.cursor.rectTransform.anchoredPosition = new Vector2(.5f, -1 - (53 * option));
	
	}
}
