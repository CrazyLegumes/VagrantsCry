using UnityEngine;
using System.Collections;
[System.Serializable]
public class Player
{
    private string pname = "Aurelia Roviere";
    private BaseStats stats = new BaseStats();

    

    public string Name
    {
        get { return pname; }
    }

    public BaseStats Stats
    {
        get { return stats; }
    }


}
