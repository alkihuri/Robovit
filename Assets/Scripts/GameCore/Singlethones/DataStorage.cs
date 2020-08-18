using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class DataStorage  
{
    public static int  levelMode = (int)Level.Low;
    public static List<LevelData> passedLevels = new List<LevelData>();
   

    public static void LoadData()
    {
        GameStates.DataStorageInit();
       if(File.Exists(Application.persistentDataPath + "/data.json")==true)
        {
            string[] data = File.ReadAllLines(Application.persistentDataPath + "/data.json");
            for (int i = 0; i < GameStates.maxLevel; i++)
            {
                passedLevels[i] = JsonUtility.FromJson<LevelData>(data[i]);
            }
        } 
    }

    public static void EraseData()
    {
        GameStates.DataStorageInit();
        SaveData();
        LoadData();
    }

    public static void SaveData()
    {
        /// сохранение прогресса 
        File.WriteAllText(Application.persistentDataPath + "/data.json","");
        foreach (LevelData ld in passedLevels)
        {
            File.AppendAllText(Application.persistentDataPath + "/data.json", JsonUtility.ToJson(ld) + '\n' );
        }
    }
}
public   class LevelData
{
    public   int currentLevel;
    public   bool letters;
    public   bool slogs;
    public   bool words;
    public bool images;
}
enum  Level
{
    Test,
    Low,
    Medium,
    High
}