using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameController : MonoBehaviour
{
    public GameObject letterToSpawn;
    public Transform [] positions;
    public int countOfCorrect = 0;
    IEnumerator SpawnCorrect()
    {
        while (1==1)
        {
            Transform random = positions[Random.Range(0, positions.Length)];
            yield return new WaitForEndOfFrame();

             if (random.childCount < 1 && GameObject.FindObjectsOfType<LetterData>().Where(o => o.isCorrectLetter == true).ToList().Count < 1)
            {
                GameObject newLetter = Instantiate(letterToSpawn, random.position, Quaternion.identity, random);
                if(countOfCorrect< GameStates.lettersOfLevel.Split(',').Length)
                {
                    string correctLetter = GameStates.lettersOfLevel.Split(',')[countOfCorrect];
                    newLetter.GetComponent<LetterData>().SetLetter(correctLetter);
                    GameObject.FindObjectOfType<AudioPlayerController>().SetAudio();
                } 
            }
           
        }
    }
    IEnumerator SpawnInCorrect()
    {
        
       while(1==1)
        {
            string inCorrectLetter = GameStates.mainAlphabet.Split(',')[Random.Range(0, GameStates.mainAlphabet.Split(',').Length)];
            Transform random = positions[Random.Range(0, positions.Length)];
            if(random.childCount<1 && GameObject.FindObjectsOfType<LetterData>().Where(o => o.isCorrectLetter == true).ToList().Count > 0)
            {
               if(!GameStates.lettersOfLevel.Contains(inCorrectLetter))
                {
                    GameObject newLetter = Instantiate(letterToSpawn, random.position, Quaternion.identity, random);
                    newLetter.GetComponent<LetterData>().SetLetter(inCorrectLetter);
                }
            }
            yield return new  WaitForEndOfFrame();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCorrect());
        StartCoroutine(SpawnInCorrect());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<LetterData>().isCorrectLetter == true)
        {
            GameObject.FindObjectOfType<CharacterData>().AddHealthPoint(-1);
        }
        Destroy(collision.gameObject);
    }


    private void Update()
    {
        if(GameObject.FindObjectsOfType<LetterToGuesController>().Where(o=>o.isGuessed == false).ToList().Count == 0)
        {
            GameObject.FindObjectOfType<SceneController>().LoadScene(GameObject.FindObjectOfType<SceneController>().next);
        }
    }
}
