using UnityEngine;
using System.Collections;

public class InGame : GameState{

    
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(Init());
       
    }


    IEnumerator Init()
    {
        yield return new WaitForSeconds(.1f);
        Game.instance.player = GameObject.Find("Player");
       
    }


   

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
