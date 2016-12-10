using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuUI : MonoBehaviour
{
    public Text Title;
    public Text StartGame;
    public Text Exit;

    [SerializeField]
    private AudioClip selectclip;

    public AudioSource select;

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




    public void Init()
    {
        select = GetComponent<AudioSource>();
        select.clip = selectclip;
        Title.text = "A Vacant Cry";
        StartGame.text = "Start";
        Exit.text = "Exit";
        Title.color = Color.clear;
        StartGame.color = Color.clear;
        Exit.color = Color.clear;
        cursor.enabled = false;
        canselect = false;


        DisableUI();

    }
    public void DisableUI()
    {
        Title.gameObject.SetActive(false);
        StartGame.gameObject.SetActive(false);
        Exit.gameObject.SetActive(false);
        cursor.gameObject.SetActive(false);
    }

    public void EnableUI()
    {
        Title.gameObject.SetActive(true);
        StartGame.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
        cursor.gameObject.SetActive(true);


    }


    void Awake()
    {
        
    }
    // Use this for initialization
    void Start()
    {


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



    void OnDestroy()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
