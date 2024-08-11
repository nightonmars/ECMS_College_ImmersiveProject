using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;


public class FMOD_SatelliteSound : MonoBehaviour
{
    public EventReference satelliteSound;
    private EventInstance satelliteSoundInst;
    public UnityEvent startTextRotation;



    public void StartSatelliteSound()
    {
        satelliteSoundInst = RuntimeManager.CreateInstance(satelliteSound);
        satelliteSoundInst.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        satelliteSoundInst.start();
        startTextRotation.Invoke(); 
    }

}
