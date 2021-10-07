using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public SteamVR_TrackedObject controller;
    public FixedJoint joint;
    public CapsuleCollider bodyCollider;
    public BoxCollider otherHandCollider;
    public Material highlightMat;

    private bool _isGrabbing = false;
    private GameObject _grabbedObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int controllerIndex = (int)controller.index;
        if (controllerIndex == -1)
            return;

        if (_isGrabbing && SteamVR_Controller.Input(controllerIndex).GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            ReleaseObj();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!_isGrabbing && other.tag == "Grabbable")
        {
            Debug.Log("HighLight");
            Highlight(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        int controllerIndex = (int)controller.index;
        if (controllerIndex == -1)
            return;

        if (!_isGrabbing && other.tag == "Grabbable" && SteamVR_Controller.Input(controllerIndex).GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            GrabObj(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            Debug.Log("UnHighLight");
            Unhighlight(other.gameObject);
        }
    }

    void GrabObj(GameObject obj)
    {
        joint.connectedBody = obj.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(bodyCollider, obj.GetComponent<Collider>(), true);
        if (otherHandCollider != null)
            Physics.IgnoreCollision(otherHandCollider, obj.GetComponent<Collider>(), true);
        _isGrabbing = true;
        Unhighlight(obj);
        _grabbedObject = obj;
    }

    void ReleaseObj()
    {
        joint.connectedBody = null;
        Physics.IgnoreCollision(bodyCollider, _grabbedObject.GetComponent<Collider>(), false);
        if (otherHandCollider != null)
            Physics.IgnoreCollision(otherHandCollider, _grabbedObject.GetComponent<Collider>(), false);
        SteamVR_Controller.Device controllerDevice = SteamVR_Controller.Input((int)controller.index);
        _grabbedObject.GetComponent<Rigidbody>().velocity = controllerDevice.velocity;
        _grabbedObject.GetComponent<Rigidbody>().angularVelocity = controllerDevice.angularVelocity;
        Unhighlight(_grabbedObject);
        _grabbedObject = null;
        _isGrabbing = false;
    }

    void OnJointBreak(float breakForce)
    {
        FixedJoint temp = gameObject.AddComponent<FixedJoint>();
        temp.breakForce = joint.breakForce;
        joint = temp;
        ReleaseObj();
    }

    void Highlight(GameObject obj)
    {
        if (obj.tag == "Grabbable" && !_isGrabbing)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
                renderer.materials = new Material[2] { renderer.material, highlightMat };
        }
    }

    void Unhighlight(GameObject obj)
    {
        if (obj.tag == "Grabbable")
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
                renderer.materials = new Material[1] { renderer.material };
        }
    }
}
