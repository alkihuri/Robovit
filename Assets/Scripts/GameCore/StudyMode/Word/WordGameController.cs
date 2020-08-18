using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordGameController : MonoBehaviour
{
    public Transform[] positions;
    public GameObject slogWordToSpawn;
    string words;
    public int countOfCorrect;
    int index;



    // Start is called before the first frame update
    void Start()
    {
        countOfCorrect = 0;
        words = GameStates.wordsOfLevel;
        StartCoroutine(DelaySpawn());
        StartCoroutine(DelayIncorectSpawn());
        GameObject.FindObjectOfType<AudioPlayerController>().SetAudio();
    }

    IEnumerator DelaySpawn()
    {
        int i = 0; 
        index = 0;
        while (i < words.Split(',')[GameStates.currentLap].Split('-').Length + 1 )
        {
            SpawnCorrectSllog();
            i++;
            yield return new WaitForEndOfFrame();
           
        }
    }

    IEnumerator DelayIncorectSpawn()
    {
        while(1==1)
        {
            yield return new WaitForEndOfFrame();
            SpawnRandonSlog();  
        }
        
    }
    public string randomCorrectSlog;
    public void SpawnCorrectSllog()
    {
        Transform random = positions[UnityEngine.Random.Range(0, positions.Length)];

        ///"МА-ЛИ-НА,СА-М,СО-М,О-СА"; .Split('-')[];
        randomCorrectSlog = words.Split(',')[GameStates.currentLap].Split('-')[index];
        int corectWordSize = words.Split(',')[GameStates.currentLap].Split('-').Length;



        if (random.childCount<1  && index < corectWordSize )
        {
            Debug.Log(index + " " + corectWordSize);
            GameObject newSlogForWordGame = Instantiate(slogWordToSpawn, random.transform.position,Quaternion.identity, random.transform); 
            newSlogForWordGame.GetComponent<WordSlogData>().SetSlog(randomCorrectSlog);
            if (index < corectWordSize )
                index++;
        }

       
    }

    private bool IsCanSpawn(string randomCorrectSlog, int num = 1)
    {
        WordSlogData[] data = GameObject.FindObjectsOfType<WordSlogData>();
        int count = data.ToList().Where(o => o.text == randomCorrectSlog).ToList().Count ;
        if (count < num)
            return true;
        else
            return false;
    }

    public void SpawnRandonSlog()
    {
        Transform random = positions[UnityEngine.Random.Range(0, positions.Length)];



        string randomInCorrectSlog = GameStates.mainAlphabet.Split(',')[UnityEngine.Random.Range(0, GameStates.mainAlphabet.Split(',').Length)] + GameStates.mainAlphabet.Split(',')[UnityEngine.Random.Range(0, GameStates.mainAlphabet.Split(',').Length)];
        if (random.childCount < 1 && !IsCanSpawn(randomCorrectSlog)) //words.Split(',')[GameStates.currentLap].Split('-').Length)
        {
            GameObject newSlogForWordGame = Instantiate(slogWordToSpawn, random.transform.position, Quaternion.identity, random.transform);

            newSlogForWordGame.GetComponent<WordSlogData>().SetSlog(randomInCorrectSlog);
        }
    }


    // Update is called once per frame
    void Update()
    {
        int countOfGuessedSyllabels = GameObject.FindObjectsOfType<WordSlogToGuessController>().ToList().Where(o => o.isGuessed == false).ToList().Count;
        if(countOfGuessedSyllabels ==0)
        { 
            if(GameStates.currentLap-1==GameStates.maxlap)
            {
                GameObject.FindObjectOfType<SceneController>().next = "Game_Word_Finish";
            }

                GameObject.FindObjectOfType<SceneController>().LoadScene(GameObject.FindObjectOfType<SceneController>().next);
            
        }
         
    }
}
