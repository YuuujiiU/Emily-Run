using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_sword : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            print("200");
            collision.gameObject.GetComponent<Enemy>().OnHit(20);
        }
    }
}
