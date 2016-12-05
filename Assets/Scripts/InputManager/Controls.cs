﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
class PlayerSettings
{
    public CharacterController body;
    public bool canmove;
    public Vector3 inp = Vector3.zero;
    public const float gravity = 30f;
    public float movespeed = 5f;
    public float jumpheight = 10f;

    
}





public class Controls : MonoBehaviour
{
    [SerializeField]
    PlayerSettings settings;
    MainMenuUI mainmenu;



    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Game.Instance.state = GameState.MainMenu;
    }
    void Start()
    {
        
       
        switch (Game.Instance.state)
        {

            case GameState.InWorld:
                settings = new PlayerSettings();
                settings.body = GameObject.Find("Player").GetComponent<CharacterController>();
                settings.canmove = true;
                break;

            case GameState.MainMenu:
                mainmenu = FindObjectOfType<MainMenuUI>();
                break;
                
        }



    }




    // Update is called once per frame
    void Update()
    {
        Debug.Log(Game.Instance.state);


        if (settings.body != null)
        {
            if (settings.body.isGrounded && Inputs.Pause())
            {
                Pause();
            }
            
        }
        switch (Game.Instance.state)
        {

            case GameState.MainMenu:
                MenuControls();
                break;

            case GameState.InWorld:
                Movement();
                break;

            case GameState.InBattle:
                break;
        }




    }

    private void Pause()
    {

        if (Game.Instance.state == GameState.InWorld)
        {
            Game.Instance.state = GameState.Pause;
            Time.timeScale = 0f;
        }
        else
        {
            Game.Instance.state = GameState.InWorld;
            Time.timeScale = 1f;
        }
    }


    private void Movement()
    {
        if (settings.canmove)
        {

            settings.inp.x = Inputs.HorizontalAxis();
            settings.inp.z = Inputs.VerticalAxis();
            settings.inp.x *= settings.movespeed;
            settings.inp.z *= settings.movespeed;

            if (settings.body.isGrounded)
            {
                settings.inp.x = Inputs.HorizontalAxis();
                settings.inp.z = Inputs.VerticalAxis();
                settings.inp.y = 0;


                settings.inp = transform.TransformDirection(settings.inp);

                settings.inp.x *= settings.movespeed;
                settings.inp.z *= settings.movespeed;


                if (Inputs.B_Button())
                {
                    settings.inp.y = settings.jumpheight;
                }
            }

            settings.inp.y -= PlayerSettings.gravity * Time.deltaTime;
            settings.body.Move(settings.inp * Time.deltaTime);
        }
    }


    private void MenuControls()
    {
        if (mainmenu.CanSelect)
        {
            if (Inputs.MenuUp())
            {
                mainmenu.selection--;
                if (mainmenu.selection < 0)
                    mainmenu.selection = 1;
            }

            if (Inputs.MenuDown())
            {
                mainmenu.selection++;
                if (mainmenu.selection > 1)
                    mainmenu.selection = 0;
            }

            mainmenu.cursor.rectTransform.localPosition = new Vector3(-53, -50 * mainmenu.selection, 0);
            

        }
    }

}

