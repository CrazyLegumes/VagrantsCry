using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mob : MonoBehaviour {
   


    public BaseEnemy Owner;
    [SerializeField]
    private GameObject owner;
    public Image cursor;



    public void Init()
    {
        Owner = owner.GetComponent<BaseEnemy>();
        cursor.gameObject.SetActive(false);
        Owner.Init();
    }
	// Use this for initialization
	void Start () {
        Init();
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Owner.Name);
	}
}
