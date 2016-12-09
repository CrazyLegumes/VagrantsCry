using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public class Mob : MonoBehaviour {
   


    public BaseEnemy Owner;
    public BaseStats mobstats;
    [SerializeField]
    private GameObject owner;
    public Image cursor;
    public Text damage;
    public bool dead;
    public bool attacked;
    private List<Skills> skills = new List<Skills>();
    public int expgiven;
    


    public void Init()
    {
        Owner = owner.GetComponent<BaseEnemy>();
        
        damage = Owner.Damage;
        cursor.gameObject.SetActive(false);
        attacked = false;
        dead = false;
        gameObject.GetComponent<Renderer>().material.color = Color.white;

        mobstats = new BaseStats();
        
        CopyStats();
        
    }


   void CopyStats()
    {
        mobstats.Health = Owner.Stats.Health;
        mobstats.MaxHealth = Owner.Stats.MaxHealth;
        mobstats.Strength = Owner.Stats.Strength;
        mobstats.MaxMana = Owner.Stats.MaxMana;
        mobstats.Speed = Owner.Stats.Speed;
        mobstats.Mana = Owner.Stats.Mana;
        mobstats.Defense = Owner.Stats.Defense;
        mobstats.Level = Owner.Stats.Level;
        mobstats.Luck = Owner.Stats.Luck;
        skills = Owner.enemySkills;
        expgiven = Owner.EXPGiven;
 

    }
	// Use this for initialization
	void Start () {
        Init();
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Owner.Name);
	}

    public void HealMe(int health)
    {
        mobstats.Health += health;
        if (mobstats.Health > mobstats.MaxHealth)
            mobstats.Health = mobstats.MaxHealth;
    }


    public void DamageMe(int dmg)
    {
        mobstats.Health -= dmg;
        if (mobstats.Health < 0)
        {
            mobstats.Health = 0;
            dead = true;
        }

        damage.text = "" + dmg;


    }

    public void Fade()
    {
        if (!dead)
            return;
        gameObject.GetComponent<Renderer>().material.DOColor(Color.clear, 1f);
    }

    public Skills GetSkillFromList()
    {
        int max = skills.Count;
        int pick = Random.Range(0, max);
        return skills[pick];
    }
}
