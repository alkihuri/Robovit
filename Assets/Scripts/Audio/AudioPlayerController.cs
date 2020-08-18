using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayerController : MonoBehaviour
{
    public AudioSource audio; 
    public void SetAudio()
    {
        string path = "";

        string sceneName = SceneManager.GetActiveScene().name;

         if(sceneName.Contains("Letter"))
            path = "Audio/Find/" + GameStates.lettersOfLevel.Split(',')[GameObject.FindObjectOfType<GameController>().countOfCorrect].ToString();

         if (sceneName.Contains("Slog"))
            path = "Audio/Find/" + GameStates.syllablesOfLevel.Split(',')[GameObject.FindObjectOfType<SlogsGameController>().countOfCorrect].ToString();
        
        if (sceneName.Contains("Word"))
            path = "Audio/Find/" + GameStates.wordsOfLevel.Split(',')[GameStates.currentLap].Replace("-","").ToString();

        if (sceneName.Contains("Image"))
            path = "Audio/Find/" + GameStates.imageWord.Replace("-","");

       // Debug.Log("path = " + path);

        audio.clip = Resources.Load<AudioClip>(path) as AudioClip;
        PlayAudio();
    }

    public void PlayAudio()
    {
        StartCoroutine(DelayPlay());
    }

    IEnumerator DelayPlay()
    {
        yield return new WaitForSeconds(0.5f);
        audio.Play();
    }
}
