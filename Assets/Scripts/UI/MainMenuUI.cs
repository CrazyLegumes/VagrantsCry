using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuUI : MonoBehaviour {
    [SerializeField]
    private Text Title;
    [SerializeField]
    private Text StartGame;
    [SerializeField]
    private Text Exit;

    [SerializeField]
    private Image cursor;


    void Awake()
    {
        Title.text = "A Vagrants Cry";
        StartGame.text = "Start";
        Exit.text = "Exit";
        Title.color = Color.clear;
        StartGame.color = Color.clear;
        Exit.color = Color.clear;
        cursor.enabled = false;
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
        yield break;

        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
