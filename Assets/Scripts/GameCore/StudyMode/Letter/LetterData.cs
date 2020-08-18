using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterData : MonoBehaviour
{
    public bool isCorrectLetter = false;
    public string text;
    // Start is called before the first frame update
    public void SetLetter(string tempLetter)
    {
        text = tempLetter;
        GetComponentInChildren<Text>().text = tempLetter;
        if(GameStates.lettersOfLevel.Contains(tempLetter) )
        {
            isCorrectLetter = true;
            if(DataStorage.levelMode ==  (int)Level.Low)
                GetComponentInChildren<SpriteRenderer>().color = Color.green;
        }
    }

   
}
