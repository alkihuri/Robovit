using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImageModeController : MonoBehaviour
{
    public Transform[] positionsToSpawn;
    public GameObject mainImageToGuess;
    public int iCurrentWordToGuess;
    public string currentWordGuess; 
    public GameObject wordToSpawn;
    public List<GameObject> listOfWordsOnScreen;
    public Text wordToGuess;
    // Start is called before the first frame update
    void Start()
    {
        iCurrentWordToGuess = 0;
        listOfWordsOnScreen = new List<GameObject>();
        SetWordOnUI();
        SpwnCorrectWord();
    }


    public void SpwnCorrectWord()
    { 
        currentWordGuess = GameStates.wordsOfLevel.Split(',')[iCurrentWordToGuess]; 
        GameStates.imageWord = currentWordGuess;
        GameObject.FindObjectOfType<AudioPlayerController>().SetAudio();
        GameObject.FindObjectOfType<AudioPlayerController>().PlayAudio();
        Transform randomPosition = positionsToSpawn[Random.Range(0, positionsToSpawn.Length)];
        string imagePath = "Images/" + currentWordGuess.Replace("-", ""); 
        
        if(DataStorage.levelMode == (int)Level.Low)
            mainImageToGuess.GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePath) as Sprite;
        if (DataStorage.levelMode > (int)Level.Low)
            wordToGuess.text = currentWordGuess.Replace("-", "");

        if (randomPosition.childCount>0)
        {
            Destroy(randomPosition.GetChild(0).gameObject);
        }
         
        GameObject newOne = Instantiate(wordToSpawn, randomPosition.transform); 
        newOne.GetComponent<ImageWordData>().isCorrectWord = true;
        newOne.GetComponent<WordImageController>().SetText(currentWordGuess);
        newOne.GetComponent<WordImageController>().SetImage();
        listOfWordsOnScreen.Add(newOne); 
        

       
    }

    IEnumerator SpwnInCorrectWord()
    { 
         
            Transform randomPosition = positionsToSpawn[Random.Range(0, positionsToSpawn.Length)];
            string randomWord = GameStates.wordsOfLevel.Split(',').ToList().Where(o => o != currentWordGuess).ToList<string>()[Random.Range(0, GameStates.wordsOfLevel.Split(',').Length-1)];

            if (randomPosition.childCount < 1)
            { 
            GameObject newOne = Instantiate(wordToSpawn, randomPosition.transform);
            newOne.GetComponent<WordImageController>().SetText(randomWord); 
            newOne.GetComponent<WordImageController>().SetImage();
            listOfWordsOnScreen.Add(newOne);
            }
            yield return new WaitForSeconds(0.01f);
        
          
    }

    IEnumerator DelayDestroy(GameObject gm)
    {
        yield return new WaitForSeconds(2);
        Destroy(gm);
    }

    public void SetNextWord()
    {
        iCurrentWordToGuess++;
        Debug.Log("iCurrentWordToGuess - " + iCurrentWordToGuess);
    
        

        foreach(GameObject gm in listOfWordsOnScreen)
        {
            Destroy(gm);
        }
        listOfWordsOnScreen.Clear();
        

        if (iCurrentWordToGuess < GameStates.wordsOfLevel.Split(',').Length)
        {
            SpwnCorrectWord();
            SetWordOnUI();
        }
        else
        {
            GameObject.FindObjectOfType<SceneController>().LoadScene(GameObject.FindObjectOfType<SceneController>().next);
            
        }

    }

    public void SetWordOnUI()
    {
        currentWordGuess = GameStates.wordsOfLevel.Split(',')[iCurrentWordToGuess]; 
    }

    private void Update()
    {
        if(listOfWordsOnScreen.Count<5)
        { 
            StartCoroutine(SpwnInCorrectWord());
        }
    }

}
