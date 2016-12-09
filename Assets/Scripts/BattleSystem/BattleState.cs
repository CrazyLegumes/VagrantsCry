using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class BattleState : State
{


    protected BattleController controller;
    public List<Transform> enemyspawn { get { return controller.enemyspawn; } }
    public Transform playerspawn { get { return controller.playerspawn; } }
    public List<GameObject> enemies { get { return controller.enemies; } }
    public BattleUI ui { get { return controller.UI; } }
    public Mob target { get { return controller.target; } set { controller.target = value; } }
    public Skills selected { get { return controller.selectedattack;  } set { controller.selectedattack = value; } }



    // Use this for initialization
    protected virtual void Awake()
    {
        controller = GetComponent<BattleController>();

    }

    protected override void AddListeners()
    {
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.LeftArrow, ShiftLeft);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.RightArrow, ShiftRight);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.Z, Fire1);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.X, Fire2);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.C, Fire3);

        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.DownArrow, ShiftDown);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.UpArrow, ShiftUp);

    }

    protected override void RemoveListeners()
    {
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.LeftArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.RightArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.Z);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.Z);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.X);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.C);

        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.DownArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.UpArrow);

    }


    protected virtual void ShiftLeft() { }
    protected virtual void ShiftRight() { }
    protected virtual void Fire1() { }
    protected virtual void Fire2() { }
    protected virtual void Fire3() { }
    protected virtual void ShiftUp() { }
    protected virtual void ShiftDown() { }

}
