using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public static class GameStates  
{

    #region levelSettings 
    public static int currentLevel = 1;
    public static int maxLevel = 12;
    public static string lettersOfLevel = "A,О,С,М";
    public static string syllablesOfLevel = "МА,СО,АС,СА";
    public static string wordsOfLevel = "МА-МА,ПА-ПА,МО-СТ,КУ-СТ";
    public static string imageWord = "МАМА";
    public static int currentLap = -1;
    public static int maxlap = wordsOfLevel.Split(',').Length;
    #endregion

    #region alphabetSettings
    public static string mainAlphabet = "А,Б,В,Г,Д,Е,Ё,Ж,З,И,Й,К,Л,М,Н,О,П,Р,С,Т,У,Ф,Ч,Ц,Ч,Ш,Щ,Ъ,Ы,Ь,Э,Ю,Я";
    public static string currentAlphabet = "RUS";
    #endregion

    #region GameSettings 
    public static bool lettersMode = true;
    public static bool syllablesMode = true;
    public static bool wordMode = true;
    #endregion

    public static void SetLevel()
    {
        
        currentLevel = DataStorage.levelMode; 
    }


    public static void DataStorageInit()
    {
        DataStorage.passedLevels.Clear();
        for(int i =0;i<maxLevel;i++)
        {
            LevelData newOne = new LevelData();
            newOne.currentLevel = i + 1;
            DataStorage.passedLevels.Add(newOne);
        }
    }

    public static void LevelInit()
    { 

        if(currentLevel!= null)
            switch (currentLevel)
            {
                case 1:
                    lettersOfLevel = "А,О,С,М";
                    wordsOfLevel = "МА-МА,ПА-ПА,МО-СТ,КУ-СТ";
                    syllablesOfLevel = "МА,МО,СА,СО";
                    Debug.Log("1й уровень...");
                break;


                case 2:
                    lettersOfLevel = "У,К,Т,Н";
                    wordsOfLevel = "КО-Т,НО-С,СО-Н,УТ-КА,КУ-СТ,МО-СТ,СО-М,УС,КО-М,НО-ТА,ТО-М,МА-К";
                    syllablesOfLevel = "КА,НА,ТА,МУ,КО,КУ,НО,НУ,ТО,ТУ,СУ";
                    Debug.Log("2й уровень...");
                break;

                case 3:
                    lettersOfLevel = "Э,П,Х,В";
                    wordsOfLevel = "ЭХ-О,ЭМ-У,ПУ-Х,УХ-О,ПА-ПА,ВО-ВА,ВА-ТА,МА-Х,МО-Х,ВО-Т,ТО-П,ТО-Т,СУ-П";
                    syllablesOfLevel = "ПА,ПО,ПУ,ВА,ВО,ВУ";
                    Debug.Log("3й уровень...");
                break;


                default:
                    Debug.Log("Ошибка!");
                break;
            }
      
    }

    
}
