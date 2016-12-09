using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnemyPool : MonoBehaviour {

    public static EnemyPool current;

    private int enemiestopool = 5;
    [SerializeField]
    private List<GameObject> EnemyTypes = new List<GameObject>();

    public List<GameObject> enemyPool;
    GameObject emptyparent;

    private bool previouslypooled;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        current = this;
    }

    void Init()
    {
        enemyPool = new List<GameObject>();

        emptyparent = Instantiate(new GameObject());
        emptyparent.name = "EnemyPool";

        for (int i = 0; i < EnemyTypes.Count; i++)
        {
            
            for (int j = 0; j < enemiestopool; j++)
            {
                GameObject obj = Instantiate(EnemyTypes[i]);
                obj.GetComponent<Mob>().Owner.Init();
                obj.name = obj.GetComponent<Mob>().Owner.Name + j;
                Debug.Log(obj.GetComponent<Mob>().Owner.ID);
                obj.SetActive(false);
                obj.transform.parent = emptyparent.transform;
                enemyPool.Add(obj);

            }
        }
        previouslypooled = true;
    }
    // Use this for initialization
    void Start()
    {
        Init();




    }

    public GameObject GetEnemies(int enemyID)
    {
        for(int i = 0; i < enemyPool.Count; i++)
        {
            
            if (!enemyPool[i].activeInHierarchy && enemyPool[i].GetComponent<Mob>().Owner.ID == enemyID)
            {
                enemyPool[i].SetActive(true);
                return enemyPool[i];
            }
        }
        return null;


    }

	
	// Update is called once per frame
	void Update () {
        if (enemyPool[0] == null && previouslypooled)
        {
            Init();
        }
        
    }

    
}
