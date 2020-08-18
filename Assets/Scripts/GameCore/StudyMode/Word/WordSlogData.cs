using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSlogData : MonoBehaviour
{
    public bool isCorrectSlog = false;
    public string text;
    // Start is called before the first frame update
    public void SetSlog(string tempSlog)
    {
        text = tempSlog;
        GetComponentInChildren<Text>().text = tempSlog;
        //  wordsOfLevel = "МА-ЛИ-НА,СА-МА,СО-М,О-СА,СА-М";
        string a = GameStates.wordsOfLevel.Split(',')[GameStates.currentLap];//.Split('-')[GameObject.FindObjectOfType<WordGameController>().countOfCorrect];
         

        if (a.Contains(tempSlog))
        {
            isCorrectSlog = true;
            if (DataStorage.levelMode == (int)Level.Low)
                GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
    }

}
