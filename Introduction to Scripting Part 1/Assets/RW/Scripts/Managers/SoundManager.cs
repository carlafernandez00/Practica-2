using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; //it stores reference to a SoundManager component

    public AudioClip shootClip;        // refernce to the sound of the hay shoot
    public AudioClip sheepHitClip;     // reference to the sound when a sheep gets hit
    public AudioClip sheepDroppedClip; // reference to the sound when a sheep drops

    private Vector3 cameraPosition;    //camera position

    // Awake to set references. Awake gets called first
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function that plays a given clip in the cam position
    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }


    // PLAYING THE SPECIFIC AUDIOFILES:
    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
}
