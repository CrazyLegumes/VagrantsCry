using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnemyPool : MonoBehaviour {


    private int enemiestopool = 5;
    [SerializeField]
    private List<GameObject> EnemyTypes = new List<GameObject>();

    public List<GameObject> enemyPool;

    private bool previouslypooled;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Init()
    {
        enemyPool = new List<GameObject>();

        for (int i = 0; i < EnemyTypes.Count; i++)
        {
            Debug.Log("Faggot");
            for (int j = 0; j < enemiestopool; j++)
            {
                GameObject obj = Instantiate(EnemyTypes[i]);
                obj.SetActive(false);
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
	
	// Update is called once per frame
	void Update () {
        if (enemyPool[0] == null && previouslypooled)
        {
            Init();
        }
        
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
	}

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log("Reinitialized");
        Init();
    }
}
