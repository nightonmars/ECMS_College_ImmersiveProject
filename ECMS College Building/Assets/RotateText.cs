using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateText : MonoBehaviour
{

    private bool rotationTrue = false; 
    public float rotationSpeed = 100f;

 
    void Update()
    {
        if(rotationTrue)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    public void StartRotation()
    {
        rotationTrue = true; 
    }
}
