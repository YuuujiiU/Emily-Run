
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using System.Collections;
using UnityEngine;

public class RotateTrueDoor : MonoBehaviour
    , IColliderEventHoverEnterHandler
{
    public GameObject switchObject;
    public bool gravityEnabled = false;
    public Vector3 impalse = Vector3.up;

    private bool m_gravityEnabled;
    private Vector3 previousGravity;
    public float minAngle;
    public float maxAngle;
    private float angle;
    public AudioClip AC;
    public AudioSource snd;

    private void Start()
    {
        //angle = Mathf.Clamp(Time.deltaTime, -30, 0);
        previousGravity = Physics.gravity;
        //SetGravityEnabled(gravityEnabled, true);
    }

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        //open door
        switchObject.transform.localEulerAngles = new Vector3(0f, 90f, 0f);

        //change scence
        Application.LoadLevel("floor2_1.1.02");
        Debug.Log("TraverseScreen");

        //sound
        //snd.enabled = true;
        //AudioSource.PlayClipAtPoint(AC, transform.localPosition);
        //Debug.Log("screeeeech!");


        //SetGravityEnabled(!m_gravityEnabled);
    }

    public void SetGravityEnabled(bool value, bool forceSet = false)
    {
        if (ChangeProp.Set(ref m_gravityEnabled, value) || forceSet)
        {
            // change the apperence the switch
            // switchObject.localEulerAngles = new Vector3(0f, value ? -90f : 0f, 0);
            //switchObject.localEulerAngles = new Vector3(0f, -90f, 0f);
            Debug.Log("Open2!");
            //angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
            //transform.eulerAngles = new Vector3(0, -angle, 0);

            StopAllCoroutines();

            // Change the global gravity in the scene
            if (value)
            {
                Physics.gravity = previousGravity;
            }
            else
            {
                previousGravity = Physics.gravity;

                StartCoroutine(DisableGravity());
            }
        }

        gravityEnabled = m_gravityEnabled;
    }

    private IEnumerator DisableGravity()
    {
        Physics.gravity = impalse;
        yield return new WaitForSeconds(0.3f);
        Physics.gravity = Vector3.zero;
    }
}