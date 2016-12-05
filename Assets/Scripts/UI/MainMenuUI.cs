using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuUI : MonoBehaviour {
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
        Title.text = "A Vagrants Cry";
        StartGame.text = "Start";
        Exit.text = "Exit";
        Title.color = Color.clear;
        StartGame.color = Color.clear;
        Exit.color = Color.clear;
        cursor.enabled = false;
        canselect = false;

        
       
    }
	// Use this for initialization
	void Start () {

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
	
	// Update is called once per frame
	void Update () {
	
	}
}
