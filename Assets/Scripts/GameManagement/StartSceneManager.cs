using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
 
    public void DataReset()
    {
        DataStorage.EraseData();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameStates.SetLevel();
        GameStates.LevelInit();
        GameStates.DataStorageInit();
        DataStorage.LoadData();
    }

    
}
