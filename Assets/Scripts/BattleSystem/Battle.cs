using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public enum battleState
{
    selectmove,
    selecttarget,
    check,
    enemyturn,
    win,
    lose
}


class Spawn
{
    public Transform Spawnpoint;
}

public class Battle : MonoBehaviour {

    List<Transform>  enemyspawn = new List<Transform>();
    Transform playerspawn;

    List<GameObject> enemies = new List<GameObject>();

    public battleState state;


    IEnumerator Setup(List<GameObject> enemymobs)
    {
        Save.SaveAllFiles();
        for(int i = 0; i < enemymobs.Count; i++)
        {
            enemies.Add(enemymobs[i]);
            enemymobs[i].transform.position = enemyspawn[i].position;
        }



        GameObject.Find("Player").transform.position = playerspawn.position;
        




        yield return null;
    }
	// Use this for initialization
	void Start () {
        


        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
