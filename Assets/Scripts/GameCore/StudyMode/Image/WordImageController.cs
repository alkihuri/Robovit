using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordImageController : MonoBehaviour
{
    public GameObject imageUI;
    public Text textUI;
    public string text; 
    // Start is called before the first frame update
    public void  SetText(string i)
    {
        text = i;
       
        
            if (DataStorage.levelMode<(int)Level.Medium)
            {
                if (GetComponent<ImageWordData>().isCorrectWord)
                    GetComponentInChildren<SpriteRenderer>().material.color = Color.green;
                textUI.text = text.Replace("-","");
            }
            if (DataStorage.levelMode > (int)Level.Low)
            {
                textUI.text = "";
            }
        
    }

    public void SetImage()
    {
        string imagePath = "Images/" + text.Replace("-","");
        if (DataStorage.levelMode > (int)Level.Low)
            imageUI.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(imagePath) as Sprite;
    }
    void Start()
    {
        
    }
     public void OnWordClick()
    {
        if (GetComponent<ImageWordData>().isCorrectWord)
        { 
            GameObject.FindObjectOfType<ImageModeController>().SetNextWord();
        }
        else
        {
            GameObject.FindObjectOfType<CameraController>().ShakeCamera();
            GameObject.FindObjectOfType<CharacterData>().AddHealthPoint(-1);
        }
    }
}
