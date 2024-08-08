using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorController : MonoBehaviour
{

    public Animator[] animators;
    

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            foreach(Animator ani in animators)
            {
                ani.SetBool("OpenDoor", true); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Animator ani in animators)
            {
                ani.SetBool("OpenDoor", false);
            }
        }
    }


}
