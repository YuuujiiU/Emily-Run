using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using System.Collections;
using UnityEngine;

public class HitMonster : MonoBehaviour
    , IColliderEventHoverEnterHandler
{
    public GameObject switchObject;
    public bool gravityEnabled = false;
    public Vector3 impalse = Vector3.up;

    private bool m_gravityEnabled;
    private Vector3 previousGravity;
    public GameObject m_Player;
    public Animator ani;
    static int damage = Animator.StringToHash("Base Layer.damage");
    static int down = Animator.StringToHash("Base Layer.down");
    static int death = Animator.StringToHash("Base Layer.death");



    private void Start()
    {
        
    }

    public void Update()
    {
        ani.SetBool("down", false);
       // ani.SetBool("death", false);
        ani.SetBool("damage", false);


        if (this.GetComponent<Enemy>().isDied())
        {
           
            ani.SetBool("down", true) ;
            print(this.GetComponent<Enemy>().isDied());
          //  ani.SetBool("death", true) ;
          //  Destroy(gameObject);
        }

    }
    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        //open door
        GetComponent<Enemy>().OnHit(m_Player.GetComponent<PlayerSC>().power);
        Debug.Log("Be Hit");
        ani.SetBool("damage", true);
    }

    private IEnumerator DisableGravity()
    {
        Physics.gravity = impalse;
        yield return new WaitForSeconds(0.3f);
        Physics.gravity = Vector3.zero;
    }
}
