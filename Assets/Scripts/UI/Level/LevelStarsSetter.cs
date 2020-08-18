using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelStarsSetter : MonoBehaviour
{
    public List<Image> spriteList;
    public Text info;
    // Start is called before the first frame update
    void Start()
    {
        if (DataStorage.levelMode >  (int)Level.Low)
        {
             
            GetComponent<AudioSource>().Play();
        }

        if (DataStorage.levelMode > 1)
        {
            GetComponent<AudioSource>().Play();
        } 
        for (int i = 0; i < 3; i++)
        {
            if ((i + 1) < DataStorage.levelMode || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Contains("Finish"))
            {
                spriteList[i].enabled = true;
            }
            else
            {
                spriteList[i].enabled = false;
            }
        }



        info.text =  GameObject.FindObjectOfType<SceneController>().info;
    }
 
}
