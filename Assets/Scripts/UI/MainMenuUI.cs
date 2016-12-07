using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private Text Title;
    [SerializeField]
    private Text StartGame;
    [SerializeField]
    private Text Exit;

    [SerializeField]
    private AudioClip selectclip;

    public AudioSource select;

    [SerializeField]
    public Image cursor;

    private bool canselect;
    public bool CanSelect
    {
        get
        {
            return canselect;
        }

        set
        {
            canselect = value;
        }
    }
    public int selection = 0;


    void Awake()
    {
        select = GetComponent<AudioSource>();
        select.clip = selectclip;
        Title.text = "A Vagrant's Cry";
        StartGame.text = "Start";
        Exit.text = "Exit";
        Title.color = Color.clear;
        StartGame.color = Color.clear;
        Exit.color = Color.clear;
        cursor.enabled = false;
        canselect = false;

        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.UpArrow, Up);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.DownArrow, Down);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.Z, Accept);



    }
    // Use this for initialization
    void Start()
    {

        StartCoroutine(FadeInTitle());
    }

    IEnumerator FadeInTitle()
    {


        Title.DOColor(Color.white, 3);
        yield return new WaitForSeconds(1.5f);
        StartGame.DOColor(Color.white, 3);
        yield return new WaitForSeconds(.5f);
        Exit.DOColor(Color.white, 3);

        yield return new WaitForSeconds(2);
        cursor.enabled = true;
        canselect = true;
        yield break;

    }

    public IEnumerator Skip()
    {
        StopAllCoroutines();
        DOTween.KillAll();
        Title.color = Color.white;
        Title.color = Color.white;
        StartGame.color = Color.white;
        Exit.color = Color.white;
        cursor.enabled = true;
        
        canselect = true;
        yield break;

    }

    public IEnumerator FadeOutTitle()
    {
        
        Title.DOColor(Color.clear, 2);
        StartGame.DOColor(Color.clear, 2);
        Exit.DOColor(Color.clear, 2);
        cursor.DOColor(Color.clear, 2);
        yield return new WaitForSeconds(2f);
        Camera.main.GetComponent<AudioListener>().enabled = false;
        yield return StartCoroutine(Game.LoadScene(1, LoadSceneMode.Additive));
        
        yield return new WaitForEndOfFrame();
        StartCoroutine(Game.UnloadScene(0));
    }


    void Up()
    {
        if (canselect)
        {
            selection--;
            if (selection < 0)
                selection = 1;
            select.Play();

        }

    }
    

    void Down()
    {
        if (canselect)
        {
            selection++;
            if (selection > 1)
                selection = 0;
            select.Play();

        }

    }

    void Accept()
    {
        if (canselect)
        {
            switch (selection)
            {
                case 0:
                    Debug.Log("Checked");
                    InputEvents.ClearList();
                    StartCoroutine(FadeOutTitle());
                    CreateChar.Init();
                    Game.Instance.state = GameState.InWorld;
                    select.Play();
                    break;

                case 1:
                    Application.Quit();
                    break;
            }
        }

        if (!canselect)
        {
            StartCoroutine(Skip());
        }
        
    }

    void OnDestroy()
    {
        InputEvents.ClearList();
    }

    // Update is called once per frame
    void Update()
    {
        cursor.rectTransform.localPosition = new Vector3(-53, -50 * selection, 0);

    }
}
