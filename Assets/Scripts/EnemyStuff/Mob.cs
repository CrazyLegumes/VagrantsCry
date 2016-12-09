using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mob : MonoBehaviour {
   


    public BaseEnemy Owner;
    public BaseStats mobstats;
    [SerializeField]
    private GameObject owner;
    public Image cursor;
    public Text damage;
    public bool dead;
    bool attacked;



    public void Init()
    {
        Owner = owner.GetComponent<BaseEnemy>();
        
        damage = Owner.Damage;
        cursor.gameObject.SetActive(false);
        attacked = false;
        dead = false;
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
}
