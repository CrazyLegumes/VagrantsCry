using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MMController : StateMachine {

    public MainMenuUI UI;
    
    public void Init()
    {
        UI = FindObjectOfType<MainMenuUI>();
        UI.Init();
        ChangeState<InitMainMenu>();
    }

    void Awake()
    {
        Init();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(CurrentState);
	
	}
}
