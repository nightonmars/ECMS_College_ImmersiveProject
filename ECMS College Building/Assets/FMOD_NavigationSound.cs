using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.Events;


public class FMOD_NavigationSound : MonoBehaviour
{
    public EventReference navSound;
    private EventInstance navSoundInst;
    public UnityEvent satelliteSoundEvent;
    public bool NavSoundTriggered = true;



    private void Start()
    {
        NavSoundTriggered = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")& NavSoundTriggered)
        {
            StartNavSound();
            satelliteSoundEvent.Invoke();
            NavSoundTriggered = false; 
        }
    }

    public void StartNavSound()
    {
        navSoundInst = RuntimeManager.CreateInstance(navSound);
        navSoundInst.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        navSoundInst.start(); 
    }

    public void SetNavSoundTriggeredBool()
    {
        NavSoundTriggered = true;
    }

}
