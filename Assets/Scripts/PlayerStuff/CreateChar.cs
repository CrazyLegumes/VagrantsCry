using UnityEngine;
using System.Collections;

public class CreateChar
{



    public static void Init()
    {
        Player.instance.Stats.Level = 1;
        Player.instance.Stats.Health = 100;
        Player.instance.Stats.MaxHealth = 100;
        Player.instance.Stats.Mana = 50;
        Player.instance.Stats.MaxMana = 50;
        Player.instance.Stats.Strength = 4;
        Player.instance.Stats.Defense = 1;
        Player.instance.Stats.Speed = 1;
        Player.instance.Stats.Luck = 1;
        Player.instance.Stats.Experience = 0;
        Player.instance.Stats.MaxExperience = 10;
        Player.instance.Skills.Add(new GenericSpamAttack());
        Player.instance.Skills.Add(new GenericHoldAttack());
        for (int i = 0; i < Player.instance.Skills.Count; i++)
            Player.instance.Skills[i].Init();

        Player.instance.basicattack.Init();
        StorePlayerInfo();
        Save.SaveAllFiles();
    }

    void Update()
    {

    }


    public static void StorePlayerInfo()
    {

        Game.instance.PlayerLevel = Player.instance.Stats.Level;
        Game.instance.PlayerName = Player.instance.Name;
        Game.instance.Health = Player.instance.Stats.Health;
        Game.instance.MaxHealth = Player.instance.Stats.MaxHealth;
        Game.instance.Mana = Player.instance.Stats.Mana;
        Game.instance.MaxMana = Player.instance.Stats.MaxMana;
        Game.instance.Strength = Player.instance.Stats.Strength;
        Game.instance.Defense = Player.instance.Stats.Defense;
        Game.instance.Speed = Player.instance.Stats.Speed;
        Game.instance.Luck = Player.instance.Stats.Luck;
        Game.instance.Experience = Player.instance.Stats.Experience;
        Game.instance.MaxExperience = Player.instance.Stats.MaxExperience;
        Game.instance.Skills = Player.instance.Skills;
    }

    public static void RetrievePlayerInfo()
    {
        
        Player.instance.Stats.Level = Game.instance.PlayerLevel;
        Player.instance.Stats.Health = Game.instance.Health;
        Player.instance.Stats.MaxHealth = Game.instance.MaxHealth;
        Player.instance.Stats.Mana = Game.instance.Mana;
        Player.instance.Stats.MaxMana = Game.instance.MaxMana;
        Player.instance.Stats.Strength = Game.instance.Strength;
        Player.instance.Stats.Defense = Game.instance.Defense;
        Player.instance.Stats.Speed = Game.instance.Speed;
        Player.instance.Stats.Luck = Game.instance.Luck;
        Player.instance.Stats.Experience = Game.instance.Experience;
        Player.instance.Stats.MaxExperience = Game.instance.MaxExperience;
        Player.instance.Skills = Game.instance.Skills;
    }
}
