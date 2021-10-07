using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour {

    public float speed = 1;

    private float posX;
    private float posY;
    private float posZ;

    // Use this for initialization
    void Start()
    {
        posX = this.gameObject.transform.position.x;//得到原来物体的位置。
        posY = this.gameObject.transform.position.y;
        posZ = this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    //每一帧都会执行一次。
    void Update()
    {
        /* if (Input.GetKey(KeyCode.W))//按W键向前移动。
             posZ +=speed * Time.deltaTime;


         if (Input.GetKey(KeyCode.S))//按S键向后移动。
             posZ -=speed * Time.deltaTime;


         if (Input.GetKey(KeyCode.A))//按A键向左移动。
             posX -=speed* Time.deltaTime;

         if (Input.GetKey(KeyCode.D))//按D键向右移动。
             posX +=speed * Time.deltaTime;
         this.gameObject.transform.position = new Vector3(posX, posY, posZ);*/
        
        if (Input.GetKey(KeyCode.W))
        {
          //  Debug.Log("update");
            transform.Translate(0, 0, -1);
        }



    }
}