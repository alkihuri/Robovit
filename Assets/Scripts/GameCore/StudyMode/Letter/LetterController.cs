using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    private void Start()
    {
        if (!GetComponent<LetterData>().isCorrectLetter)
            StartCoroutine(DelayDestroy(25));
    }

    IEnumerator DelayDestroy ( float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
    public void OnClickLetter()
    {
        if(GetComponent<LetterData>().isCorrectLetter)
        {
             
            
            foreach(LetterToGuesController some in GameObject.FindObjectsOfType<LetterToGuesController>())
            {
                if(some.text.Equals(GetComponent<LetterData>().text))
                {
                    some.isGuessed = true;
                }
            }
            GameObject.FindObjectOfType<GameController>().countOfCorrect++;
            GameObject.FindObjectOfType<CharacterController>().mouseIsHappy = true;
        }
        else
        {
            GameObject.FindObjectOfType<CameraController>().ShakeCamera();
            GameObject.FindObjectOfType<CharacterController>().mouseIsSad = true;
            GameObject.FindObjectOfType<CharacterData>().AddHealthPoint(-1);
        }

        foreach(LetterController gm in GameObject.FindObjectsOfType<LetterController>())
        {
            Destroy(gm.gameObject);
        }

        StartCoroutine(DelayDestroy(.01f));
    }
}
