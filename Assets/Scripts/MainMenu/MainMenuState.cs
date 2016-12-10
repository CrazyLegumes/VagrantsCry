using UnityEngine;
using System.Collections;

public class MainMenuState : State{
    protected MMController controller;
    public MainMenuUI ui { get { return controller.UI; } }

	// Use this for initialization
	protected virtual void Awake()
    {
        controller = GetComponent<MMController>();
        
    }



    protected override void AddListeners()
    {
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.LeftArrow, ShiftLeft);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.RightArrow, ShiftRight);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.Z, Fire1);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.X, Fire2);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.DownArrow, ShiftDown);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.UpArrow, ShiftUp);
        Debug.Log("added");
    }

    protected override void RemoveListeners()
    {
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.LeftArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.RightArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.Z);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.X);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.DownArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.UpArrow);
        Debug.Log("Removed");
    }



    protected virtual void ShiftLeft() { }
    protected virtual void ShiftRight() { }
    protected virtual void Fire1() { }
    protected virtual void Fire2() { }
    protected virtual void ShiftUp() { }
    protected virtual void ShiftDown() { }


    // Update is called once per frame
}
