using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    public string uniqePath;
    public VideoPlayer vp;

    public bool letter, syllabels, word, image;

    // Start is called before the first frame update
    void Start()
    {
        if (letter)
            uniqePath = "/Letters/"  + GameStates.lettersOfLevel.Replace(",", "");
        if (syllabels)
            uniqePath = GameStates.syllablesOfLevel;
        if (word)
            uniqePath = GameStates.wordsOfLevel;
        if(image)
            uniqePath = GameStates.wordsOfLevel;

        
       

        uniqePath = "Video" + uniqePath;
        Debug.Log(uniqePath);
        vp.clip = Resources.Load<VideoClip>(uniqePath);
        vp.Play();
    }

    private void Update()
    {
        Debug.Log(((int)vp.frameCount).ToString()  + "/"  +  ((int)vp.frame).ToString());

        if (((int)vp.frameCount - (int)vp.frame)<2)
        {
            GameObject.FindObjectOfType<SceneController>().LoadScene(GameObject.FindObjectOfType<SceneController>().next);
        }
    }
}
