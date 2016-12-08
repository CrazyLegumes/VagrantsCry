using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class BaseEnemy : MonoBehaviour
{
    private string ename;
    [SerializeField]
    private int id;

    [SerializeField]
    private Image cursor;
   
    [System.NonSerialized]
    private BaseStats stats = new BaseStats();




    private int expgiven;

    [SerializeField]
    private List<GameObject> mobs = new List<GameObject>();





    public BaseEnemy()
    {

    }

    public virtual void Init() { }

    public Image Cursor
    {
        get { return cursor; }
        set { cursor = value; }
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
