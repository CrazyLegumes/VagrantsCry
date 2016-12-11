using UnityEngine;
using System.Collections;

public class InMainMenu : GameState {

    public override void Enter()
    {
        base.Enter();
        mainMenu.Init();
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
