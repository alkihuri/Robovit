using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetSlogsToGuess : MonoBehaviour
{
    public GameObject letterToGues;
    public Text mainLetter;
    public GameObject content;
    float offset;
    public Scrollbar scHorizontal;
    public List<GameObject> letterOnScreen; 
    // Start is called before the first frame update
    void Start()
    { 
        letterOnScreen = new List<GameObject>();
        offset = 300;
        List<string> letters = GameStates.syllablesOfLevel.Split(',').ToList();
        for (int i = 0; i < letters.Count; i++)
        {
            GameObject newOne = Instantiate(letterToGues, content.transform);

            float height = content.GetComponent<RectTransform>().rect.height;

            content.GetComponent<RectTransform>().anchoredPosition = new Vector2(  i * offset, 0);
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(i * offset, height);
            newOne.GetComponent<RectTransform>().anchoredPosition = new Vector3( 130  + i * offset, 0, 0);
            newOne.GetComponent<SlogToGuesController>().SetText(letters[i]);
            letterOnScreen.Add(newOne);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int index = GameObject.FindObjectOfType<SlogsGameController>().countOfCorrect;

        
        if (DataStorage.levelMode < (int)Level.High)
        {
             
            if (index < GameStates.syllablesOfLevel.Split(',').Length)
                mainLetter.text = GameStates.syllablesOfLevel.Split(',')[index];
              

        }

        else
        {
            mainLetter.text = "";
        }


       
    }
}
