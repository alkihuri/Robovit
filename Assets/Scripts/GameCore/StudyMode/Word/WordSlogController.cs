using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSlogController : MonoBehaviour
{
 
    IEnumerator DelayDestroy(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
    public void OnClickSlog()
    {
        WordSlogToGuessController slogToGuess = GameObject.FindObjectsOfType<WordSlogToGuessController>()[GameObject.FindObjectsOfType<WordSlogToGuessController>().Length - 1 - GameObject.FindObjectOfType<WordGameController>().countOfCorrect];


        if (GetComponent<WordSlogData>().isCorrectSlog && slogToGuess.text.Equals(GetComponent<WordSlogData>().text))
        {
             
            slogToGuess.isGuessed = true;

            /*
            foreach (WordSlogToGuessController some in GameObject.FindObjectsOfType<WordSlogToGuessController>())
            {
                if (some.text.Equals(GetComponent<WordSlogData>().text))
                {
                    some.isGuessed = true;
                    break;
                }
            }
            */
            GameObject.FindObjectOfType<WordGameController>().countOfCorrect++;
            GameObject.FindObjectOfType<CharacterController>().mouseIsHappy = true;

            StartCoroutine(DelayDestroy(.02f));
        }
        else
        {
            GameObject.FindObjectOfType<CameraController>().ShakeCamera();
            GameObject.FindObjectOfType<CharacterController>().mouseIsSad = true;
            GameObject.FindObjectOfType<CharacterData>().AddHealthPoint(-1);
        }
     

        /*
        foreach (WordSlogController gm in GameObject.FindObjectsOfType<WordSlogController>())
        {
            Destroy(gm.gameObject);
        }
        */
    }
}
