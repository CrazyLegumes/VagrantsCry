using UnityEngine;
using System.Collections;

public enum attacktype
{
    Time,
    Spam,
    Hold
}

[System.Serializable]
public class Skills
{
    private int id;
    private string name;
    private int cost; // mana cost;
    private attacktype type;
    private string desc;
    private float timer;
    private int dmg;
    private float bound;
    



    public virtual void Init() { }

    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
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

    public int Damage
    {
        get { return dmg; }
        set { dmg = value; }
    }

    public float Bound
    {
        get { return bound; }
        set { bound = value; }
    }

   
    


}
