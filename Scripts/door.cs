using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;

public class door : MonoBehaviour
{
    public Space rotateSpace;
    float angle;
    public float minAngle;
    public float maxAngle;

    //public void Rotate(Vector3 eulerAngles, Space relativeTo = Space.World)
    //{

    //}
    void Start()
    {
       angle = Mathf.Clamp(Time.deltaTime, -30, 0);

    }
    //void Update()
    //{
    //    //if ()
    //    {
    //        //transform.Rotate(new Vector3(0, -70, 0));
    //        angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
    //        transform.eulerAngles = new Vector3(0, angle, 0);
    //    }
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
            transform.eulerAngles = new Vector3(0, -angle, 0);
        }
    }

    
}
