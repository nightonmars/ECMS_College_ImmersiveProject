using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class FMOD_GlassDoor : MonoBehaviour
{
   public EventReference doorSliding;
   private GameObject doorSlidingObject;


   private void Start()
   {
      doorSlidingObject = gameObject; // Directly reference this GameObject
   }

   public void GlassDoorSound()
   {
      RuntimeManager.PlayOneShotAttached(doorSliding, doorSlidingObject);
   }
}
