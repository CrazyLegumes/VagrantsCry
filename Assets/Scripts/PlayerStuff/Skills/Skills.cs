using UnityEngine;
using System.Collections;

public enum attacktype
{
    Time,
    Spam,
    Hold
}
public class Skills
{
    private int id;
    private int cost; // mana cost;
    private attacktype type;
    private string desc;
    private float timer;


 
    public virtual void Init() { }

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public attacktype Type
    {
        get { return type; }
        set { type = value; }
    }

    public string Desc
    {
        get { return desc; }
        set { desc = value; }
    }

    public float Timer
    {
        get { return timer; }
        set { timer = value; }
    }


}
