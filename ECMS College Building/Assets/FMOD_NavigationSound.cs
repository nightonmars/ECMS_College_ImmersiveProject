using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.Events;
using System.Collections;

public class FMOD_NavigationSound : MonoBehaviour
{
    public EventReference navStartSound;
    public EventReference navSound;
    private EventInstance navSoundInst;
    public UnityEvent satelliteSoundEvent;
    public bool NavSoundTriggered = false;
    public float WaitToStartSound = 2f;

    private void Start()
    {
        NavSoundTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !NavSoundTriggered)
        {
            PlayStartNavSound();
            StartCoroutine(StartNavSoundCoroutine());
            satelliteSoundEvent.Invoke();
            NavSoundTriggered = true; 
        }
    }

    public void PlayStartNavSound()
    {
        RuntimeManager.PlayOneShot(navStartSound);
    }

    private IEnumerator StartNavSoundCoroutine()
    {
        yield return new WaitForSeconds(WaitToStartSound); // Wait for 2 seconds
        navSoundInst = RuntimeManager.CreateInstance(navSound);
        navSoundInst.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
        navSoundInst.start();
    }

    public void SetNavSoundTriggeredBool()
    {
        NavSoundTriggered = false;
    }
}