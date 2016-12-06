using UnityEngine;
using System.Collections;

public class BaseStats
{
    //Stats Needed
    //Strength
    //Speed
    //HP
    //MP
    //Defense
    //Luck
    //Experience
    //Level

    private int strength;
    private int level;
    private int speed;
    private int health;
    private int maxhealth;
    private int mana;
    private int maxmana;
    private int defense;
    private int luck;
    private int experience;
    private int maxexperience;


    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int Speed
    {
        get { return speed; }
        set { speed = value; }

    }

    public int Health
    {
        get { return health; }
        set { health = value; }

    }

    public int MaxHealth
    {
        get { return maxhealth; }
        set { maxhealth = value; }
    }

    public int Mana
    {
        get { return mana; }
        set { mana = value; }

    }

    public int MaxMana
    {
        get { return maxmana; }
        set { maxmana = value; }
    }

    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }

    public int Luck
    {
        get { return luck; }
        set { luck = value; }
    }


    public int Experience
    {
        get { return experience; }
        set { experience = value; }

    }

    public int MaxExperience
    {
        get { return maxexperience; }
        set { maxexperience = value; }
    }

}

