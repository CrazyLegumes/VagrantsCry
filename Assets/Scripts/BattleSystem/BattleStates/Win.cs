﻿using UnityEngine;
using System.Collections;

public class Win : BattleState {


    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
    }


    IEnumerator Init()
    {
        yield return null;
        Player.Instance.Stats.Experience += expgain;
        Player.Instance.CheckLevelUp();
        controller.ChangeState<EndBattle>();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
