using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour {

    
	
	public static void SaveAllFiles()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream save = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);
        bf.Serialize(save, Game.instance.PlayerName);
        bf.Serialize(save, Game.instance.PlayerLevel);
        bf.Serialize(save, Game.instance.Health);
        bf.Serialize(save, Game.instance.MaxHealth);
        bf.Serialize(save, Game.instance.Mana);
        bf.Serialize(save, Game.instance.MaxMana);
        bf.Serialize(save, Game.instance.Strength);
        bf.Serialize(save, Game.instance.Defense);
        bf.Serialize(save, Game.instance.Speed);
        bf.Serialize(save, Game.instance.Luck);
        bf.Serialize(save, Game.instance.Experience);
        bf.Serialize(save, Game.instance.MaxExperience);
        bf.Serialize(save, Game.instance.Skills);

        save.Close();


       

        Debug.Log("Saved Stats!");
    }
	
}
