using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour {
    //public Transform target;
    private UnityEngine.AI.NavMeshAgent Enemy;
    private GameObject m_player;
    public Animator ani;
    static int attack01 = Animator.StringToHash("Base Layer.attack01");
    

    // Use this for initialization
    void Start () {
        Enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_player = GameObject.FindWithTag("wanjia");
       
    }
	
	// Update is called once per frame
	void Update () {
        ani.SetBool("attack01", false);     
        
        //if (Vector3.Distance(m_player.transform.position, this.transform.position) <= 10)
        //{
          //  print("look");
           // this.transform.LookAt(new Vector3(m_player.transform.position.x, 0, m_player.transform.position.z));
            if (Vector3.Distance(m_player.transform.position, this.transform.position) <= 6f)
            {
            this.transform.LookAt(new Vector3(m_player.transform.position.x, 0, m_player.transform.position.z));
            print("attack");
                ani.SetBool("attack01", true);
                m_player.GetComponent<PlayerSC>().GetHurt(GetComponent<Enemy>().GetAtk());
        }
        else
        {
            Enemy.SetDestination(new Vector3(m_player.transform.position.x - 3f, 0, m_player.transform.position.z - 3f));
        }
   
     
    }
}
