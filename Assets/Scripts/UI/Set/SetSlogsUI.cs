using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSlogsUI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = GameStates.syllablesOfLevel.Replace(",", " ,");
        StartCoroutine(ChangeColorWithDelay());
    }
    IEnumerator ChangeColorWithDelay()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(1);
            GetComponent<Text>().color = Random.ColorHSV();
        }
    }
 
}
