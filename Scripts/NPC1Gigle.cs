using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC1Gigle : MonoBehaviour {

    public AudioClip AC;
    public AudioSource snd;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {

        snd.enabled = true;
        AudioSource.PlayClipAtPoint(AC, transform.localPosition);
        Debug.Log("giggle!");
    }
}
