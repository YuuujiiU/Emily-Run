/*
Player script
Use on player perfab to calculate the properties' value of the player.
Doesn't provide player control methods.
This script provides functions to send data when you want to save the game.

Created by Liu Zishu, on 2/7/2017
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSC : MonoBehaviour 
{
	//Basic and max value of player
	public int power = 1;
	public float speed = 8f;
	public int MaxBandge = 3;
	public int MaxAmmo = 25;
	public int MaxDefence = 20;

	//Start position
	public Transform spawnpoint;

	//The values use in game, save and load
	private int Ammo = 0;
	private float HP = 15.0f;
	private int Defence = 0;
	private int Bandge = 0;


    //When player dies, call this function translating player to the spawnpoint
    //and reset HP to maxium, zero other values
    private void Death()
	{
		HP = 15.0f;
		Ammo = 0;
		Defence = 0;
		Bandge = 0;
		this.transform.position = spawnpoint.transform.position;
	}

	//When enemy die, give player the reward(ammo)
	public void GetAmmo(int _get)
	{
		Ammo += _get;
		if (Ammo > MaxAmmo)
			Ammo = MaxAmmo;
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy" )//&& device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            collision.gameObject.GetComponent<Enemy>().OnHit(power);
        }
    }

    //When attacked by enemy, deal the damage to the player.
    //If player dies, call the Death() method to end the game.
    public void GetHurt(int _atk)
	{
		float Harm = _atk * (1 - Defence * 0.01f);
		if (Harm > 0.1f)
			HP -= Harm;
		else
			HP -= 0.1f;
		
		if (HP <= 0.0f)
			Death ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//When player uses the bandge to restore the hit point
	public void RestoreHealth()
	{
		if (Bandge > 0) 
		{
			HP += 3.0f;
			if (HP > 10f)
				HP = 10.0f;
			Bandge--;
		}
		else
			return;
	}

	//When player gets bandge(s) from the scenes
	//Default number is 1
	public void GetBandge(int _num = 1)
	{
		Bandge += _num;
		if (Bandge > MaxBandge)
			Bandge = MaxBandge;
	}

	//TODO: judge whether player can use the cross bow to attack the enemy
	//if player can attack, Ammo-1
	//Return value(bool): true = can, false = cannot
	public bool RangeAttack()
	{
		if (Ammo > 0) 
		{
			Ammo--;
			return true;
		}
		else
			return false;
	}

	public void GetDefence()
	{
		Defence += 4;
		if (Defence > MaxDefence)
			Defence = MaxDefence;
	}

	//These functions below use when save the game data
	//Return the data we want to save
	public float ReturnHP()
	{
		return HP;
	}

	public int ReturnAmmo()
	{
		return Ammo;
	}

	public int ReturnDef()
	{
		return Defence;
	}

	public int ReturnBandge()
	{
		return Bandge;
	}

	//When load game, send data to this function
	//Send data in sequence(ammo(int), defence value(int), the number of bandge(int), hit point(float)) 
	public void Load(int _ammo, int _def, int _bandge, int _hp)
	{
		Ammo = _ammo;
		Defence = _def;
		Bandge = _bandge;
		HP = _hp;
	}
}
