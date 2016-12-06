using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public enum battleState
{
    init,
    selectmove,
    selecttarget,
    check,
    enemyturn,
    win,
    lose
}




public class Battle : MonoBehaviour
{
    [SerializeField]
    private List<Transform> enemyspawn = new List<Transform>();

    [SerializeField]
    private Transform playerspawn;

    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();

    public battleState state;


    public IEnumerator Setup(GameObject enemy)
    {
        List<GameObject> enemymobs = enemy.GetComponent<BaseEnemy>().Mobs;
        enemy.SetActive(false);
        Save.SaveAllFiles();
        for (int i = 0; i < enemymobs.Count; i++)
        {

            enemies.Add(EnemyPool.current.GetEnemies(enemymobs[i].GetComponent<BaseEnemy>().ID));
            enemies[i].transform.position = enemyspawn[i].position;
            enemies[i].SetActive(true);


        }



        GameObject.Find("Player").transform.position = playerspawn.position;
        yield return null;
    }
    // Use this for initialization
    void Start()
    {
        state = battleState.init;





    }

    // Update is called once per frame
    void Update()
    {

    }
}
