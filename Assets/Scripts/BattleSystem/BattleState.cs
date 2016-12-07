using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class BattleState : State
{


    protected BattleController controller;
    public List<Transform> enemyspawn { get { return controller.enemyspawn; } }
    public Transform playerspawn { get { return controller.playerspawn; } }
    public List<GameObject> enemies { get { return controller.enemies; } }



    // Use this for initialization
    protected virtual void Awake()
    {
        controller = GetComponent<BattleController>();

    }

    protected override void AddListeners()
    {
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.LeftArrow, ShiftLeft);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.RightArrow, ShiftRight);
        InputEvents.RegisterKeyEvent(InputPhase.ButtonDown, KeyCode.Z, Accept);

    }

    protected override void RemoveListeners()
    {
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.LeftArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.RightArrow);
        InputEvents.RemoveKeyEvent(InputPhase.ButtonDown, KeyCode.Z);
    }


    protected virtual void ShiftLeft() { }
    protected virtual void ShiftRight() { }
    protected virtual void Accept() { }

}
