using UnityEngine;
using System.Collections;
[System.Serializable]
public class Player
{
    private static Player instance;
    private string pname;
    private BaseStats stats;

    public static Player Instance
    {
        get
        {
            if (instance == null)
                instance = new Player();
            return instance;
        }
    }
    

    private Player()
    {
        pname = "Aurelia Roviere";
        stats = new BaseStats();
    }



    public string Name
    {
        get { return pname; }
    }

    public BaseStats Stats
    {
        get { return stats; }
    }



    public void CheckLevelUp()
    {
        if (Stats.Experience < Stats.MaxExperience)
            return;

        Debug.Log("Level up!");
        int bonus = Stats.Experience - Stats.MaxExperience;
        Stats.Experience = bonus;
        Stats.Level++;
        Stats.MaxHealth += Stats.Level * 5;
        Stats.Strength += (int)(Stats.Level * 1.5);
        Stats.Defense += (int)(Stats.Level * 1.3);
        Stats.Speed += (int)(Stats.Speed * 1.5);
        Stats.MaxMana += Stats.Level * 3;
        Stats.Luck += Random.Range(1, 4);

    }

    public void AddExperience(int exp)
    {
        Stats.Experience += exp;
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
