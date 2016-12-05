using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Load : MonoBehaviour
{

    public static void LoadItUp()
    {

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
           
            Game.Instance.PlayerName = (string)bf.Deserialize(file);
            Game.Instance.PlayerLevel = (int) bf.Deserialize(file);
            Game.Instance.Health = (int) bf.Deserialize(file);
            Game.Instance.MaxHealth = (int) bf.Deserialize(file);
            Game.Instance.Mana = (int) bf.Deserialize(file);
            Game.Instance.MaxMana = (int) bf.Deserialize(file);
            Game.Instance.Strength = (int)bf.Deserialize(file);
            Game.Instance.Defense = (int) bf.Deserialize(file);
            Game.Instance.Speed = (int) bf.Deserialize(file);
            Game.Instance.Luck = (int) bf.Deserialize(file);
            Game.Instance.Experience = (int) bf.Deserialize(file);
            Game.Instance.MaxExperience = (int) bf.Deserialize(file);
            file.Close();







        }
        

    }
}
