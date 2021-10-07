using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBornPoint : MonoBehaviour {
    public GameObject[] enemyPrefab;
    //public GameObject[] enemySpawpoint;
    private Rect spawnArea;
    public float spawnTime = 30f;
    private float CurrentTime;
    public Transform player;
    public int Num = 0;


    [Header("SpawnArea")]
    public float Width;
    public float Height;

    // Use this for initialization
    void Start()
    {
        spawnArea.width = Width;
        spawnArea.height = Height;
        spawnArea.x = this.transform.position.x;
        spawnArea.y = this.transform.position.z; 
    }

    public void SpawnEnemy(char _flag)
    {
        if (Num >= 2)
            return;
        
          Debug.Log("x" + (player.position.x - spawnArea.x));
             Debug.Log("y" + (player.position.z - spawnArea.y));
     
        
        if (( Mathf.Abs(player.position.x - spawnArea.x) >= Width * 2 ||  Mathf.Abs(player.position.z - spawnArea.y) >= Height * 2) )
       
        {
            for (int i = 0; i < enemyPrefab.Length; i++)
            {
                Debug.Log("Born");
                Instantiate(enemyPrefab[i], new Vector3(Random.Range(spawnArea.x, spawnArea.x + spawnArea.width), 1, Random.Range(spawnArea.y, spawnArea.y + spawnArea.height)), Quaternion.identity);
                enemyPrefab[i].GetComponent<Enemy>().RemarkBornPoint(_flag);
            }
            
        }
        Num += 2;
    }

    void Update()
    {
        //if (player.transform.position.z >= -23.4f)
        //{
        //    InvokeRepeating("SpawnEnemy", 50f, spawnTime);
        //}
        //else
        //    return;
    }


}
