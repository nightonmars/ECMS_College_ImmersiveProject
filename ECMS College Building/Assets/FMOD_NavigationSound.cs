using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.Events;
using System.Collections;

public class FMOD_NavigationSound : MonoBehaviour
{
    public EventReference navStartSound;
    public EventReference navSound;
    private EventInstance navSoundInst; // Instance of the current navigation sound
    public UnityEvent satelliteSoundEvent;
    public bool NavSoundTriggered = false;
    public float WaitToStartSound = 2f;

    // Static field to track the currently active sound instance
    private static EventInstance activeNavSoundInst;
    private static FMOD_NavigationSound activePortal;

    private void Start()
    {
        NavSoundTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !NavSoundTriggered)
        {
            StopActiveNavSound(); // Stop the currently active navigation sound
            PlayStartNavSound();
            StartCoroutine(StartNavSoundCoroutine());
            satelliteSoundEvent.Invoke();
            NavSoundTriggered = true;

            // Set this portal as the currently active one
            activePortal = this;
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

        // Update the active sound instance
        activeNavSoundInst = navSoundInst;
    }

    // Method to stop the currently active navigation sound
    private void StopActiveNavSound()
    {
        if (activeNavSoundInst.isValid())
        {
            activeNavSoundInst.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            activeNavSoundInst.release();
            activeNavSoundInst.clearHandle();
        }

        if (activePortal != null)
        {
            activePortal.NavSoundTriggered = false; // Reset the flag for the previously active portal
        }
    }

    private void OnDisable()
    {
        // Ensure the sound instance is stopped and released when this script is disabled
        if (navSoundInst.isValid())
        {
            navSoundInst.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            navSoundInst.release();
        }
    }
}
