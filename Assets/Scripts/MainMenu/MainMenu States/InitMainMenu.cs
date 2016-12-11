using UnityEngine;
using System.Collections;
using DG.Tweening;

public class InitMainMenu : MainMenuState
{
    bool canselect = false;
    

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        yield return new WaitForSeconds(.1f);
        ui.EnableUI();
        canselect = false;
        ui.Title.DOColor(Color.white, 3);
        yield return new WaitForSeconds(1.5f);
        ui.StartGame.DOColor(Color.white, 3);
        yield return new WaitForSeconds(.5f);
        ui.Exit.DOColor(Color.white, 3);

        yield return new WaitForSeconds(2);
        ui.cursor.enabled = true;
        canselect = true;
        NextState();
        yield break;
    }


    protected override void Fire1()
    {
        base.Fire1();
        Debug.Log("Doot");
        StopAllCoroutines();
        DOTween.KillAll();
        ui.Title.color = Color.white;
        ui.Title.color = Color.white;
        ui.StartGame.color = Color.white;
        ui.Exit.color = Color.white;
        ui.cursor.enabled = true;
        canselect = true;
        NextState();
        
    }


    void NextState()
    {
        if (canselect)
        {
            controller.ChangeState<SelectMode>();
        }
    }

    void Update()
    {

    }
}
