using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public List<GameObject> sprites;

    public void AddHealthPoint(int i = 1)
    {
        
            currentHealth += i;
    }
    private void Start()
    {
        currentHealth = 3;
        maxHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            if ((i + 1) <= currentHealth)
            {
                sprites[i].SetActive(true);
            }
            else
            {
                sprites[i].SetActive(false);
            }
        }
         if(currentHealth==0)
        {
            GameObject.FindObjectOfType<SceneController>().LoadScene("Finish_Bad");
        }
    }
}
