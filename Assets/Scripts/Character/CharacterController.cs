using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public Animator animator;
    public bool mouseIsHappy; 
    public bool mouseIsSad;
    public bool mouseIsIdle;

    public AudioSource happySound, sadSoud;

    public void HappyMouse()
    {
        mouseIsHappy = true;
    }
    public void SadMouse()
    {
        mouseIsSad = true;
    }
    private void LateUpdate()
    {
        mouseIsIdle = true;
        mouseIsSad = false;
        mouseIsHappy = false;
    }
    private void Update()
    { 
        

        if (mouseIsSad)
        {
            sadSoud.Play();
            animator.SetTrigger("Sad");
        }
        if (mouseIsHappy)
        {
            happySound.Play();
            animator.SetTrigger("Happy");
        }
        if(mouseIsIdle)
        {
            animator.SetTrigger("Idle");
        }
 
    }
   
}
