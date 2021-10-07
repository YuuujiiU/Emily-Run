using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1f;
    public SteamVR_TrackedObject[] controllers;
    public Transform[] guns;
    public Rigidbody rb;
    private float time;
    public float double_speed = 4f;
    private float s;
    public Camera cam;
    private GameObject _player;
    //public GameObject CamRig;
    public MajorWalkSound mws;


    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindWithTag("1P");
        rb.transform.position = cam.transform.position;
        //_player.transform.position = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Walk()
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            if ((int)controllers[i].index == -1)
                continue;

            if (SteamVR_Controller.Input((int)controllers[i].index).GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {

            }
        }
    }

    void Move()
    {
        for (int i = 0; i < controllers.Length; i++)
        {
            if ((int)controllers[i].index == -1)
                continue;


            if (SteamVR_Controller.Input((int)controllers[i].index).GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {

                if (SteamVR_Controller.Input((int)controllers[i].index).GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
                {
                    if (Time.realtimeSinceStartup - time <= 0.5f)
                    {
                        //Debug.Log("double");
                        s = double_speed; 
                    }
                    else
                    {
                        //Debug.Log("single");
                        s = speed;
                    }
                }

                rb.AddForce(cam.transform.forward * s);
                SteamVR_Controller.Input((int)controllers[i].index).TriggerHapticPulse(800);
                Debug.Log("mws.SoundState():" + mws.SoundState() );
                if (!mws.SoundState()) {
                    //mws.PlaySound();
                    Debug.Log("step...");
                }
                    
                time = Time.realtimeSinceStartup;
            }
            else
            {
                ;//mws.StopSound();
            }
        }
        this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
