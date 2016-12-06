﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseEnemy
{
    private string ename;

    [System.NonSerialized]
    private BaseStats stats = new BaseStats();
    
    private int expgiven;

    [SerializeField]
    private List<GameObject> mobs = new List<GameObject>();



    public BaseEnemy()
    {

        
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
