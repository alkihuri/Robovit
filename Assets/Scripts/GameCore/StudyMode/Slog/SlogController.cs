using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlogController : MonoBehaviour
{

    private void Start()
    {
        if (!GetComponent<SlogData>().isCorrectSlog)
            StartCoroutine(DelayDestroy(25));
    }

    IEnumerator DelayDestroy(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
    public void OnClickSlog()
    {
        if (GetComponent<SlogData>().isCorrectSlog)
        {
           

            foreach (SlogToGuesController some in GameObject.FindObjectsOfType<SlogToGuesController>())
            {
                if (some.text.Equals(GetComponent<SlogData>().text))
                {
                    some.isGuessed = true;
                    
                }
            }
            GameObject.FindObjectOfType<SlogsGameController>().countOfCorrect++;
            GameObject.FindObjectOfType<CharacterController>().mouseIsHappy = true;
            GameObject.FindObjectOfType<SetSlogsToGuess>().scHorizontal.value += 0.08f;
        }
        else
        {
            GameObject.FindObjectOfType<CameraController>().ShakeCamera();
            GameObject.FindObjectOfType<CharacterController>().mouseIsSad = true;
            GameObject.FindObjectOfType<CharacterData>().AddHealthPoint(-1);
        }

        foreach (SlogController gm in GameObject.FindObjectsOfType<SlogController>())
        {
            Destroy(gm.gameObject);
        }

        StartCoroutine(DelayDestroy(.01f));
    }
}
