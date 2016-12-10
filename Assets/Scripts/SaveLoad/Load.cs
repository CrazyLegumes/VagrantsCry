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
           
            Game.instance.PlayerName = (string)bf.Deserialize(file);
            Game.instance.PlayerLevel = (int) bf.Deserialize(file);
            Game.instance.Health = (int) bf.Deserialize(file);
            Game.instance.MaxHealth = (int) bf.Deserialize(file);
            Game.instance.Mana = (int) bf.Deserialize(file);
            Game.instance.MaxMana = (int) bf.Deserialize(file);
            Game.instance.Strength = (int)bf.Deserialize(file);
            Game.instance.Defense = (int) bf.Deserialize(file);
            Game.instance.Speed = (int) bf.Deserialize(file);
            Game.instance.Luck = (int) bf.Deserialize(file);
            Game.instance.Experience = (int) bf.Deserialize(file);
            Game.instance.MaxExperience = (int) bf.Deserialize(file);
            file.Close();







        }
        

    }
}
