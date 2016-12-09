using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

[System.Serializable]
public class BaseEnemy : MonoBehaviour
{
    private string ename;
    [SerializeField]
    private int id;

    [SerializeField]
    private Text damage;
   
    [System.NonSerialized]
    private BaseStats stats = new BaseStats();




    private int expgiven;

    [SerializeField]
    private List<GameObject> mobs = new List<GameObject>();





    public BaseEnemy()
    {

    }

    public virtual void Init() {
        damage.gameObject.SetActive(false);
        for(int i = 0; i < mobs.Count; i++)
        {
            if (mobs != null)
                mobs[i].GetComponent<Mob>().Init();
        }

    }

    public Text Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public List<GameObject> Mobs
    {
        get
        {
            return mobs;
        }

    }

    public string Name
    {
        get
        {
            return ename;
        }
        set { ename = value; }
    }

    public BaseStats Stats
    {
        get
        {
            return stats;
        }
    }

    public int EXPGiven
    {
        get { return expgiven; }
        set { expgiven = value; }
    }


    
    






}
