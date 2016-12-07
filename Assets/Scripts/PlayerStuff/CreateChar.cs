﻿using UnityEngine;
using System.Collections;

public class CreateChar
{



    public static void Init()
    {
        Player.Instance.Stats.Level = 1;
        Player.Instance.Stats.Health = 100;
        Player.Instance.Stats.MaxHealth = 100;
        Player.Instance.Stats.Mana = 50;
        Player.Instance.Stats.MaxMana = 50;
        Player.Instance.Stats.Strength = 1;
        Player.Instance.Stats.Defense = 1;
        Player.Instance.Stats.Speed = 1;
        Player.Instance.Stats.Luck = 1;
        Player.Instance.Stats.Experience = 0;
        Player.Instance.Stats.MaxExperience = 10;
        StorePlayerInfo();
        Save.SaveAllFiles();
    }

    void Update()
    {

    }


    public static void StorePlayerInfo()
    {

        Game.Instance.PlayerLevel = Player.Instance.Stats.Level;
        Game.Instance.PlayerName = Player.Instance.Name;
        Game.Instance.Health = Player.Instance.Stats.Health;
        Game.Instance.MaxHealth = Player.Instance.Stats.MaxHealth;
        Game.Instance.Mana = Player.Instance.Stats.Mana;
        Game.Instance.MaxMana = Player.Instance.Stats.MaxMana;
        Game.Instance.Strength = Player.Instance.Stats.Strength;
        Game.Instance.Defense = Player.Instance.Stats.Defense;
        Game.Instance.Speed = Player.Instance.Stats.Speed;
        Game.Instance.Luck = Player.Instance.Stats.Luck;
        Game.Instance.Experience = Player.Instance.Stats.Experience;
        Game.Instance.MaxExperience = Player.Instance.Stats.MaxExperience;
    }

    public static void RetrievePlayerInfo()
    {
        
        Player.Instance.Stats.Level = Game.Instance.PlayerLevel;
        Player.Instance.Stats.Health = Game.Instance.Health;
        Player.Instance.Stats.MaxHealth = Game.Instance.MaxHealth;
        Player.Instance.Stats.Mana = Game.Instance.Mana;
        Player.Instance.Stats.MaxMana = Game.Instance.MaxMana;
        Player.Instance.Stats.Strength = Game.Instance.Strength;
        Player.Instance.Stats.Defense = Game.Instance.Defense;
        Player.Instance.Stats.Speed = Game.Instance.Speed;
        Player.Instance.Stats.Luck = Game.Instance.Luck;
        Player.Instance.Stats.Experience = Game.Instance.Experience;
        Player.Instance.Stats.MaxExperience = Game.Instance.MaxExperience;
    }
}
