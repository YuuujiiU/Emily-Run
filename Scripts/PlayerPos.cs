using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour {


    public Camera cam;

	// Use this for initialization
	void Start () {
        this.transform.position = cam.GetComponent<CapsuleCollider>().transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = cam.transform.position;
    }
}
