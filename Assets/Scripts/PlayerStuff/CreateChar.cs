using UnityEngine;
using System.Collections;

public class CreateChar : MonoBehaviour
{
    private Player newplayer;

    void Start()
    {

        newplayer = new Player();

        newplayer.Stats.Level = 1;
        newplayer.Stats.Health = 100;
        newplayer.Stats.MaxHealth = 100;
        newplayer.Stats.Mana = 50;
        newplayer.Stats.MaxMana = 50;
        newplayer.Stats.Strength = 1;
        newplayer.Stats.Defense = 1;
        newplayer.Stats.Speed = 1;
        newplayer.Stats.Luck = 1;
        newplayer.Stats.Experience = 0;
        newplayer.Stats.MaxExperience = 10;
        StorePlayerInfo();

        Save.SaveAllFiles();

        




    }

    void Update()
    {
        if (Inputs.A_Button())
        {
            Debug.Log("Killem");
        }
    }


    private void StorePlayerInfo()
    {
        
        Game.Instance.PlayerLevel = newplayer.Stats.Level;
        Game.Instance.PlayerName = newplayer.Name;
        Game.Instance.Health = newplayer.Stats.Health;
        Game.Instance.MaxHealth = newplayer.Stats.MaxHealth;
        Game.Instance.Mana = newplayer.Stats.Mana;
        Game.Instance.MaxMana = newplayer.Stats.MaxMana;
        Game.Instance.Strength = newplayer.Stats.Strength;
        Game.Instance.Defense = newplayer.Stats.Defense;
        Game.Instance.Speed = newplayer.Stats.Speed;
        Game.Instance.Luck = newplayer.Stats.Luck;
        Game.Instance.Experience = newplayer.Stats.Experience;
        Game.Instance.MaxExperience = newplayer.Stats.MaxExperience;
    }
}
