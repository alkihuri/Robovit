using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlogsGameController : MonoBehaviour
{
    public GameObject slogToSpawn;
    public Transform[] positions;
    public int countOfCorrect = 0;
    IEnumerator SpawnCorrect()
    {
        while (1 == 1)
        {
            Transform random = positions[Random.Range(0, positions.Length)]; 
           
            if (random.childCount < 1  && GameObject.FindObjectsOfType<SlogData>().Where(o => o.isCorrectSlog == true).ToList().Count < 1)
            {
                GameObject newSlog = Instantiate(slogToSpawn, random.position, Quaternion.identity, random);
                if (countOfCorrect < GameStates.syllablesOfLevel.Split(',').Length   )
                {
                    string correctSlog = GameStates.syllablesOfLevel.Split(',')[countOfCorrect];
                    newSlog.GetComponent<SlogData>().SetSlog(correctSlog);
                    GameObject.FindObjectOfType<AudioPlayerController>().SetAudio();
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator SpawnInCorrect()
    {

        while (1 == 1)
        {
            string inCorrectSlog = GameStates.mainAlphabet.Split(',')[Random.Range(0, GameStates.mainAlphabet.Split(',').Length)] + GameStates.mainAlphabet.Split(',')[Random.Range(0, GameStates.mainAlphabet.Split(',').Length)];
            Transform random = positions[Random.Range(0, positions.Length)];
            if (random.childCount < 1 && GameObject.FindObjectsOfType<SlogData>().Where(o => o.isCorrectSlog == true).ToList().Count > 0)
            {
                if (!GameStates.syllablesOfLevel.Contains(inCorrectSlog))
                {
                    GameObject newSlog = Instantiate(slogToSpawn, random.position, Quaternion.identity, random);
                    newSlog.GetComponent<SlogData>().SetSlog(inCorrectSlog);
                }
            }
            yield return new WaitForEndOfFrame();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCorrect());
        StartCoroutine(SpawnInCorrect());
    }

 

    private void Update()
    {
        if (GameObject.FindObjectsOfType<SlogToGuesController>().Where(o => o.isGuessed == false).ToList().Count == 0)
        {
            GameObject.FindObjectOfType<SceneController>().LoadScene(GameObject.FindObjectOfType<SceneController>().next);
        }
    }
}
