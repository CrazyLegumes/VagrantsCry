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
        bf.Serialize(save, Game.Instance.PlayerName);
        bf.Serialize(save, Game.Instance.PlayerLevel);
        bf.Serialize(save, Game.Instance.Health);
        bf.Serialize(save, Game.Instance.MaxHealth);
        bf.Serialize(save, Game.Instance.Mana);
        bf.Serialize(save, Game.Instance.MaxMana);
        bf.Serialize(save, Game.Instance.Strength);
        bf.Serialize(save, Game.Instance.Defense);
        bf.Serialize(save, Game.Instance.Speed);
        bf.Serialize(save, Game.Instance.Luck);
        bf.Serialize(save, Game.Instance.Experience);
        bf.Serialize(save, Game.Instance.MaxExperience);

        save.Close();


       

        Debug.Log("Saved Stats!");
    }
	
}
