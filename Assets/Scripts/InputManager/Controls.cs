﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

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
    
    [SerializeField]
    BasicMob mob;


    

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Game.instance.state = GameState.MainMenu;
        
    }

    

    void Init()
    {
        switch (Game.instance.state)
        {

            case GameState.InWorld:

                settings = new PlayerSettings();
                settings.body = GameObject.Find("Player").GetComponent<CharacterController>();
                settings.canmove = true;
                mob = GameObject.Find("Basic Man").GetComponent<BasicMob>();
               
                break;

            case GameState.MainMenu:
                mainmenu = FindObjectOfType<MainMenuUI>();
                break;

        }
    }
    void Start()
    {
        Init();

    }




    // Update is called once per frame
    void Update()
    {
        Debug.Log(Player.instance.Stats.Health);
        Debug.Log(Game.instance.state);


        if (settings.body != null)
        {
            if (settings.body.isGrounded && Inputs.Pause())
            {
                Pause();
            }

        }
        switch (Game.instance.state)
        {

            case GameState.MainMenu:

               // MenuControls();
                break;

            case GameState.InWorld:
                SceneManager.sceneLoaded += SceneManager_sceneLoaded1;
                Movement();
                break;

            case GameState.InBattle:
                
                break;
        }




    }

    private void SceneManager_sceneLoaded1(Scene arg0, LoadSceneMode arg1)
    {
        Init();
    }

    private void Pause()
    {

        if (Game.instance.state == GameState.InWorld)
        {
            Game.instance.state = GameState.Pause;
            Time.timeScale = 0f;
        }
        else
        {
            Game.instance.state = GameState.InWorld;
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
        if (!mainmenu.CanSelect && Inputs.A_Button())
        {
            StartCoroutine(mainmenu.Skip());
        }
        if (mainmenu.CanSelect)
        {
            if (Inputs.MenuUp())
            {
                mainmenu.selection--;
                if (mainmenu.selection < 0)
                    mainmenu.selection = 1;
                mainmenu.select.Play();
            }

            if (Inputs.MenuDown())
            {
                mainmenu.selection++;
                if (mainmenu.selection > 1)
                    mainmenu.selection = 0;
                mainmenu.select.Play();
            }

            mainmenu.cursor.rectTransform.localPosition = new Vector3(-53, -50 * mainmenu.selection, 0);


            if (Inputs.A_Button())
            {
                switch (mainmenu.selection)
                {
                    case 0:

                        StartCoroutine(mainmenu.FadeOutTitle());
                        CreateChar.Init();
                        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
                        Game.instance.state = GameState.InWorld;
                        mainmenu.select.Play();
                        break;

                    case 1:
                        Application.Quit();
                        break;
                }
            }







        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Init();
    }
}

