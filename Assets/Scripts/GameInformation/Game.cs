using UnityEngine;
using System.Collections;
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
public class Game
{
    private static Game instance = new Game();


    private Game()
    {

    }


    public static Game Instance
    {
        get
        {
            if (instance == null)
                instance = new Game();

            return instance;
        }
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




}
