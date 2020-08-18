using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string  next;
    public  string info;
    private void OnApplicationQuit()
    {
        DataStorage.SaveData();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            DataStorage.EraseData();
        }
    }
    private void Start()
    {
        
    }
    private void Awake()
    {
        

        string name = SceneManager.GetActiveScene().name;
        switch(name)
        {
            case "Start":
                DataStorage.LoadData();
                GameStates.currentLap = -1;
            break;
            case "Game_Letter_1":
                DataStorage.levelMode = (int)Level.Low;
                
                info = "Учим буквы. 1-й уровень";
            break;

            case "Game_Letter_2":
                DataStorage.levelMode = (int)Level.Medium; 
                info = "Учим буквы. 2-й уровень";
                break;

            case "Game_Letter_3":
                DataStorage.levelMode = (int)Level.High;
                info = "Учим буквы. 3-й уровень";
                break;
            case "Game_Letter_Finish":
                if (DataStorage.passedLevels[GameStates.currentLevel - 1] != null)
                    DataStorage.passedLevels[GameStates.currentLevel - 1].letters = true;
                DataStorage.SaveData();
             break;

            case "Game_Slog_1":
                DataStorage.levelMode = (int)Level.Low;
                info = "Учим слоги. 1-й уровень";
                break;

            case "Game_Slog_2":
                DataStorage.levelMode = (int)Level.Medium;
                info = "Учим слоги. 2-й уровень";
                break;

            case "Game_Slog_3":
                DataStorage.levelMode = (int)Level.High;
                info = "Учим слоги. 3-й уровень";
                break;
            case "Game_Slog_Finish":
                if (DataStorage.passedLevels[GameStates.currentLevel - 1] != null)
                    DataStorage.passedLevels[GameStates.currentLevel - 1].slogs = true;
               
                 DataStorage.SaveData();
            break;



            case "Game_Word_1":
                DataStorage.levelMode = (int)Level.Low;
                GameStates.currentLap++;
                
                GameStates.maxlap = GameStates.wordsOfLevel.Split(',').Length;
                info = "Учим слово\n1-й уровень ";// + GameStates.currentLap +  "/" + GameStates.maxlap;
               
                break;

            case "Game_Word_2":
                DataStorage.levelMode = (int)Level.High;
                info = "Учим слово\n2-й уровень ";// + GameStates.currentLap + "/" + GameStates.maxlap;
                break;

            case "Game_Word_3":
                DataStorage.levelMode = (int)Level.High;
                info = "Учим слово\n3-й уровень ";// + GameStates.currentLap + "/" + GameStates.maxlap;

                break;
            case "Game_Word_Finish":
                if(DataStorage.passedLevels[GameStates.currentLevel - 1] != null)
                    DataStorage.passedLevels[GameStates.currentLevel - 1].words = true;
                DataStorage.SaveData();
                GameStates.currentLap = -1;
            break;


            case "Game_Image_1":
                DataStorage.levelMode = (int)Level.Low;
                
                info = "Находим  слово по картинке\n1-й уровень ";// + GameStates.currentLap +  "/" + GameStates.maxlap;
            break;

            case "Game_Image_2":
                DataStorage.levelMode = (int)Level.High;
                info = "Находим  слово по картинке\n2-й уровень ";// + GameStates.currentLap + "/" + GameStates.maxlap;
                break;

            case "Game_Image_3":
                DataStorage.levelMode = (int)Level.High;
                info = "Находим  слово по картинке\n3-й уровень ";// + GameStates.currentLap + "/" + GameStates.maxlap;

                break;
            case "Game_Image_Finish":
                if (DataStorage.passedLevels[GameStates.currentLevel - 1] != null)
                    DataStorage.passedLevels[GameStates.currentLevel - 1].images = true;
                DataStorage.SaveData(); 
            break;



        }
        
       
        GameStates.LevelInit();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
