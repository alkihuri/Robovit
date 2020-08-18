using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    public int levelNum;
    

    public void SetLevel()
    {
       // if(Progress.availaibleLevels.Contains(levelNum))
        GameStates.currentLevel = levelNum;
        GameObject.FindObjectOfType<SceneController>().LoadScene("ChooseExer");
    }
}
