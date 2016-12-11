using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MMController : StateMachine {

    public MainMenuUI UI;
    
    public void Init()
    {

        UI.Init();
        ChangeState<InitMainMenu>();
    }

    void Awake()
    {

       
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(CurrentState);
	
	}
}
