using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetStuddyWord : MonoBehaviour
{
    public GameObject wordSlogToSpawn; 
    float offset;
    public List<GameObject> letterOnScreen;
    public Text word;
    // Start is called before the first frame update
    void Start()
    {
        letterOnScreen = new List<GameObject>();
        offset = 255;
        WordGameController wgcontroller = GameObject.FindObjectOfType<WordGameController>();
        ///"МА-МА,СА-М,СО-М,О-СА";
        List<string> letters = GameStates.wordsOfLevel.Split(',')[GameStates.currentLap].Split('-').ToList();
        for (int i = 0; i < letters.Count; i++)
        {
            GameObject newOne = Instantiate(wordSlogToSpawn, transform);
            newOne.GetComponent<RectTransform>().anchoredPosition = new Vector3(i * offset, 0, 0);
            newOne.GetComponent<WordSlogToGuessController>().SetText(letters[i]);
            letterOnScreen.Add(newOne);
        }
        if(word)
        {
            if (DataStorage.levelMode < (int)Level.High)
            {

                word.text = GameStates.wordsOfLevel.Split(',')[GameStates.currentLap];
            }
            else
            {
                word.text = "";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int index = GameObject.FindObjectOfType<WordGameController>().countOfCorrect;
        
    }
}
