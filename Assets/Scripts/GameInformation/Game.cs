using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public enum GameState
{


    //Game states that I want
    MainMenu,
    Pause,
    InWorld,
    InBattle,
    GameOver,
    Credits

}


[System.Serializable]
public class Game : StateMachine
{

    public MMController mainmenu;
    public BattleController battle;

   


    private Game()
    {

    }


    public static Game instance;


   void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public static IEnumerator LoadScene(int scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
       
        yield return new WaitForSeconds(.1f);
        SceneManager.LoadSceneAsync(scene, mode);
        
    }

    public static IEnumerator SetActiveScene(Scene scene)
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.SetActiveScene(scene);
    }

    public static IEnumerator UnloadScene(int scene)
    {
        yield return new WaitForSeconds(.1f);
        SceneManager.UnloadScene(scene);
    }


    public string PlayerName { get; set; }
    public int PlayerLevel { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Mana { get; set; }
    public int MaxMana { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Luck { get; set; }
    public int Speed { get; set; }
    public int Experience { get; set; }
    public int MaxExperience { get; set; }
    public Vector3 position { get; set; }
    public GameState state { get; set; }
    public bool isPaused { get; set; }
    public List<Skills> Skills { get; set; }




}
