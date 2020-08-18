using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlogData : MonoBehaviour
{
    public bool isCorrectSlog = false;
    public string text;
    // Start is called before the first frame update
    public void SetSlog(string tempSlog)
    {
        text = tempSlog;
        GetComponentInChildren<Text>().text = tempSlog;
        if (GameStates.syllablesOfLevel.Contains(tempSlog))
        {
            isCorrectSlog = true;
            if (DataStorage.levelMode == (int)Level.Low)
                GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
    }

}
