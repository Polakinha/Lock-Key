using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    private Animator animator;
     private AudioSource audioSource;



    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }
    public void GateMove()
    {
        Debug.Log("Gate opens");
        audioSource.Play();
        animator.SetTrigger("open");
        Invoke("Final", 4);
        Invoke("Ending", 9);
    }
    private void Final()
    {
        UIGameMenu.UI.finalBlackout();

    }
    private void Ending()
    {
        ScenesManager.Instance.LoadNextScene();
    }

}
