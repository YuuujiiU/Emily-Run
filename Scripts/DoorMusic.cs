using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMusic : MonoBehaviour {

    public AudioClip AC;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    //或者OnTriggerEnter(Collider collider)  
    {
        //if ()
        //{ //被撞得物体原点发出声音（第二个参数用来设置发出声音的世界坐标，不要离AudioListener太远）  
        //    AudioSource.PlayClipAtPoint(AC, transform.localPosition);
        //}
        

    }
}
