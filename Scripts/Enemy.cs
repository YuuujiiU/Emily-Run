/*
Enemy script
Use on the enemy perfabs for comobats, melee attack only

Created by Liu Zishu, on 2/7/2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//Enemy level, default 1(the lowest level)
	public int level = 1;

	//Player's tag in the scene, can't be null
	public string PlayerTag = null;

	//Basic property of the enemy
	private int power;
	private float HP;
	private float speed;
	private int Drop;

    //Remark which spaenpoint did this enemy born
    private char flag = 'a';

	//To know this enemy is alive or not, false means alive, true means dies.
	//Inital value is false
	private bool isDead;

	//Player in the scene
	private GameObject m_Player;

	//TODO: find player in the scene for initalization, initalize the enemy
	void Start()
	{
		if (PlayerTag == null)
			Debug.Log ("No player was found!");
		m_Player = GameObject.FindWithTag (PlayerTag);
		Init (m_Player.GetComponent<PlayerSC>().power);
	}

    //TODO: return enemy's attack value
    //Return value(int): power
    public int GetAtk()
    {
        return power;
    }

	//TODO: initalize enemy based on its level and player's attack value
	//level 6 is the most powerful enemy in this game, player can't beat it
	public void Init(int _playerPower)
	{
		if (level <= 0)
			level = 1;
		if (level > 6)
			level = 6;

		if (level <= 3) 
		{
			speed = (float)level + 7f;
			HP = level * _playerPower;
			Drop = (int)HP + 1;
		} 
		else if (level == 4) 
		{
			speed = 8f;
			HP = level * _playerPower;
			Drop = (int)HP + 2;
		}
		else if (level == 5) 
		{
			speed = 7f;
			HP = (level + 3) * _playerPower;
			Drop = (int)HP - 3;
		}

		if (level == 6) {
			speed = 5f;
			HP = 1000;
			Drop = 0;
			power = 2000;
		} else
			power = level; 
		isDead = false;
	}

	//TODO: give player the reward(ammo) and destroy the dead gameobject
	private void Death()
	{
		m_Player.GetComponent<PlayerSC>().GetAmmo (this.Drop);
		//Destroy (gameObject);
	}

	//TODO: attack player and calculate the damage
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "MainCamera") 
		{
			m_Player.gameObject.GetComponent<PlayerSC>().GetHurt(this.power);
		}
	}

	//Attacked by player, judge whether this enemy is alive
	//if not, change isDead's state to true
	public void OnHit(int _power)
	{
		HP -= _power;
		if (HP <= 0) 
		{
			isDead = true;
            Death();
        }
	}

	//TODO: tell the system the enemy is dead.
	//Return value(bool): isDead. True means die, false means alive.
	public bool isDied()
	{
		return isDead;
	}

    //TODO: make it clearly that which area's enemies died, help to reduce the number of the enemy in this area.
    public void RemarkBornPoint(char _born)
    {
        flag = _born;
    }

    public char ReturnFlag()
    {
        return flag;
    }
}