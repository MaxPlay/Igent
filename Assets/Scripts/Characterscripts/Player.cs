using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	public int MaxHP = 100;
	public float Regencooldown = 0f;
	public float TimeUntilRegeneration = 5.0f;
	public float CurrentRegencooldown = 0f;
	public int HP = 100;


	void Start () 
	{
	
	}
	public void TakeDamage(int _Damage)
	{
		HP -= _Damage;
		Regencooldown = 0;
	}
	public void Regeneration()
	{
		if(HP < MaxHP)
		HP += 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (TimeUntilRegeneration <= Regencooldown)
			Regeneration ();
		CurrentRegencooldown += Time.deltaTime;
		if (Regencooldown > 10f)
			Regencooldown = TimeUntilRegeneration+0.1f;
	}
}
