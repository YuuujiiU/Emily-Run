/*
 这个脚本用来把场景划分成三个部分，依据z坐标进行划分。
 生成敌人时依据玩家当前所处的区域进行生成

 用来限制怪物行动范围的方法或许和这个类似，但我没有试过
 比起比较四个边界值，只判断z轴好像更简单

 给每个敌人附带的标签我能够表示出某个区域内的敌人死亡
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    //public GameObject Swap;
    public GameObject[] enemySpawpoint;
    public GameObject _player;
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
    //根据玩家所在区域控制敌人生成
    //我依照场景中墙的z坐标吧场景分成三个区域，并给每个区域的敌人增加了标签属性和数量限制
    //敌人生成的速度很快，两个一组
	public void Update () {
        if (_player.transform.position.z > 8.1f)
        {
            enemySpawpoint[2].GetComponent<EnemyBornPoint>().SpawnEnemy('c');
        }
        if (_player.transform.position.z > -19.5f && _player.transform.position.z <= 8.1f)
            enemySpawpoint[1].GetComponent<EnemyBornPoint>().SpawnEnemy('b');
        if(_player.transform.position.z <= -19.5f)
            enemySpawpoint[0].GetComponent<EnemyBornPoint>().SpawnEnemy('a');
    }

}
