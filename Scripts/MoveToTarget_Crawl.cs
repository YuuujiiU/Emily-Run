using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget_Crawl : MonoBehaviour {

    private UnityEngine.AI.NavMeshAgent Enemy;
    private GameObject m_player;
    public Animator ani;
    static int attack = Animator.StringToHash("Base Layer.attack");


    // Use this for initialization
    void Start()
    {
        Enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_player = GameObject.FindWithTag("wanjia");
        GetComponent<Enemy>().Init(1);
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetBool("attack", false);
        //    ani.SetBool("attack", false);

      // Enemy.SetDestination(new Vector3(m_player.transform.position.x - 3f, 0, m_player.transform.position.z - 3f));

        if (Vector3.Distance(m_player.transform.position, this.transform.position) <= 9f)
        {
            this.transform.LookAt(new Vector3(m_player.transform.position.x, 0, m_player.transform.position.z));
            print("attack");
            ani.SetBool("attack", true);
            m_player.GetComponent<PlayerSC>().GetHurt(2000);
        }
        else { Enemy.SetDestination(new Vector3(m_player.transform.position.x - 3f, 0, m_player.transform.position.z - 3f));
           // Debug.Log("distance" + Vector3.Distance(m_player.transform.position, this.transform.position));
        }
          

    }
}


