using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SelectMode : MainMenuState
{
    bool canselect = false;
    int option = 1;
    Sequence cur;


    public override void Enter()
    {
        canselect = true;
        base.Enter();
        UpdateCursor();
        
    }

    IEnumerator LoadGame()
    {

        canselect = false;
        ui.Title.DOColor(Color.clear, 2);
        ui.StartGame.DOColor(Color.clear, 2);
        ui.Exit.DOColor(Color.clear, 2);
        ui.cursor.DOColor(Color.clear, 2);
        yield return new WaitForSeconds(2f);
        Camera.main.GetComponent<AudioListener>().enabled = false;
        yield return StartCoroutine(Game.LoadScene(1, LoadSceneMode.Additive));
        Game.instance.ChangeState<InGame>();
        CreateChar.Init();
        yield return new WaitForEndOfFrame();
        StartCoroutine(Game.UnloadScene(0));
    }




    protected override void Fire1()
    {

        base.Fire1();
        if (canselect)
        {
            switch (option)
            {
                case 1:
                    StartCoroutine(LoadGame());
                    ui.select.Play();
                    break;

                case -1:
                    Application.Quit();
                    break;
            }
        }
    }

    protected override void ShiftDown()
    {
        if (canselect)
        {
            option += 2;
            if (option > 1)
                option = -1;
            UpdateCursor();
            base.ShiftDown();
            ui.select.Play();

        }
    }

    protected override void ShiftUp()
    {
        if (canselect)
        {
            option -= 2;
            if (option < -1)
                option = 1;

            UpdateCursor();
            base.ShiftUp();
            ui.select.Play();

        }
    }


    void UpdateCursor()
    {
        ui.cursor.rectTransform.anchoredPosition = new Vector2(-160f, 113f * (1f * option));
        
    }

    void Update()
    {
        
    }




}
