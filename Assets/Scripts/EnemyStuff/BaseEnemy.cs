using UnityEngine;
using System.Collections;

public class BaseEnemy{
    private string ename;
    private BaseStats stats;
    private int expgiven;




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
