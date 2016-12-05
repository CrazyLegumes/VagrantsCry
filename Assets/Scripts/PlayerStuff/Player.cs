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



    public void DamageMe(int damage)
    {
        Stats.Health -= damage;
        if (Stats.Health < 0)
            Stats.Health = 0;
    }

    public void HealMe(int heal)
    {
        Stats.Health += heal;
        if (Stats.Health > Stats.MaxHealth)
            Stats.Health = Stats.MaxHealth;
    }


}
