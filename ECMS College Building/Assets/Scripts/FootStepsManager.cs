using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio; 
 

public class FootStepsManager : MonoBehaviour
{
    private PhysicsPM_MatDetector detector;
    public EventReference footStepsEvent;
    private EventInstance footStepsEventInstance;

    private void Start()
    {
        detector = GetComponent<PhysicsPM_MatDetector>();
    }

    public void FootStepDown()
    {
        footStepsEventInstance = RuntimeManager.CreateInstance(footStepsEvent);
        footStepsEventInstance.start();
        footStepsEventInstance.setParameterByName("Terrain", detector.matIdx);
        Debug.Log("FootStepDown" +detector.matIdx);
    }
}
