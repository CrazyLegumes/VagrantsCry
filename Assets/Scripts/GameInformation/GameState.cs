using UnityEngine;
using System.Collections;

public class GameState : State {

    public MMController mainMenu { get { return controller.mainmenu; } }
    public BattleController battle { get { return controller.battle; } }

    protected Game controller;



    protected virtual void Awake()
    {
        controller = Game.instance;
    }

    protected override void AddListeners()
    {
        //Movement Listeners
        InputEvents.RegisterKeyEvent(InputPhase.ButtonHold, KeyCode.LeftArrow, Left);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonHold, KeyCode.RightArrow, Right);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonHold, KeyCode.DownArrow, Down);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonHold, KeyCode.UpArrow, Up);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.X, Jump);

        //ActionListeners
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.Escape, Pause);
    }


    protected override void RemoveListeners()
    {
        InputEvents.RemoveKeyEvent(InputPhase.ButtonHold, KeyCode.LeftArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonHold, KeyCode.RightArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonHold, KeyCode.DownArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonHold, KeyCode.UpArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.X);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.Escape);

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}


    protected virtual void Left() { }
    protected virtual void Right() { }
    protected virtual void Down() { }
    protected virtual void Up() { }
    protected virtual void Jump() { }
    protected virtual void Pause() { }
    
}
