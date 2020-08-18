using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetLettersToGues : MonoBehaviour
{
    public GameObject letterToGues;
    public Text mainLetter;
    float offset;
    public List<GameObject> letterOnScreen; 
    // Start is called before the first frame update
    void Start()
    {
        letterOnScreen = new List<GameObject>();
        offset = 255;
        List <string> letters  = GameStates.lettersOfLevel.Split(',').ToList();
        for(int i=0;i< letters.Count;i++)
        {
            GameObject newOne = Instantiate(letterToGues, transform);
            newOne.GetComponent<RectTransform>().anchoredPosition = new Vector3(i * offset, 0, 0); 
            newOne.GetComponent<LetterToGuesController>().SetText(letters[i]);
            letterOnScreen.Add(newOne);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int index = GameObject.FindObjectOfType<GameController>().countOfCorrect;
        try
        {
            if (DataStorage.levelMode < (int)Level.High)
                mainLetter.text = GameStates.lettersOfLevel.Split(',')[index];
            else
                mainLetter.text = "";
        }
        finally
        {
             
        }
    }
}
