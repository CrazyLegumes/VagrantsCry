using UnityEngine;
using System.Collections;


public abstract class BattleState : State{
    

    protected BattleController controller;
   
    

    // Use this for initialization
    protected virtual void Awake()
    {
        controller = GetComponent<BattleController>();
        
    }

    protected override void AddListeners()
    {
        
    }
   
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
