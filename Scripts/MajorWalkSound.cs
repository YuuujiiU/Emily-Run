using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorWalkSound : MonoBehaviour {

    public AudioClip AC;
    public AudioSource snd;

    public void PlaySound() {
        snd.enabled = true;
        AudioSource.PlayClipAtPoint(AC, transform.localPosition);
        Debug.Log("MajorWalkSound!");
    }

    //public void StopSound()
    //{
    //    snd.enabled = false;
    //    //Debug.Log("MajorWalkStopSound!");
    //}

    public bool SoundState()
    {
        return snd.isPlaying;
    }

}
