using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ChooceExerSceneController : MonoBehaviour
{
  
    public Button lettersInfo, slogsInfo, wordInfo, imagesInfo;
    // Start is called before the first frame update
    void Start()
    {
        lettersInfo.GetComponentInChildren<Text>().text += ":\n" + GameStates.lettersOfLevel;
        if(DataStorage.passedLevels[GameStates.currentLevel-1].letters)
        {
            lettersInfo.gameObject.GetComponent<Image>().color = Color.green;
        }
        slogsInfo.GetComponentInChildren<Text>().text += ":\n" +GameStates.syllablesOfLevel;
        if (DataStorage.passedLevels[GameStates.currentLevel-1].slogs)
        {
            slogsInfo.gameObject.GetComponent<Image>().color = Color.green;
        }
        wordInfo.GetComponentInChildren<Text>().text += ":\n" + GameStates.wordsOfLevel.Replace("-","").Replace(",",", ");
        if (DataStorage.passedLevels[GameStates.currentLevel-1].words)
        {
            wordInfo.gameObject.GetComponent<Image>().color = Color.green;
        }

        if (DataStorage.passedLevels[GameStates.currentLevel - 1].images)
        {
            imagesInfo.gameObject.GetComponent<Image>().color = Color.green;
        }

        slogsInfo.interactable = DataStorage.passedLevels.Where(o=>o.currentLevel == GameStates.currentLevel).ToList()[0].letters;
        wordInfo.interactable = DataStorage.passedLevels.Where(o => o.currentLevel == GameStates.currentLevel).ToList()[0].slogs;
        imagesInfo.interactable = DataStorage.passedLevels.Where(o => o.currentLevel == GameStates.currentLevel).ToList()[0].words;
        GameStates.currentLap = -1;
    }

    
}
