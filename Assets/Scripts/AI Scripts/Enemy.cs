using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{


	public float MovementSpeed = 1.0f;
	public float AttackRange = 1f;
	public float AttackSpeed = 1f;
	public float cooldown = 0.0f;
	public int Damage = 5;
	public int CurrentWaypoint = 0;
	public int StartWaypoint = 0;
	public Transform[] Waypoint;
	public LayerMask sightlayer;	
	public Transform player;
    public Vector3 CurrentMoveDirection;

    private Quaternion bla = new Quaternion();
	private RaycastHit raycastHit;
	
	void Start () 
	{
		if(StartWaypoint!=0)
			CurrentWaypoint = StartWaypoint-1;
		else
			CurrentWaypoint = 0;
	}
	
	public bool CanSeePlayer()
	{
		if(Physics.Raycast(transform.position, (player.position - transform.position).normalized, out raycastHit, 1000.0f,sightlayer.value))
			{
				
				if(raycastHit.collider.transform == player)
					return true;
			}
		return false;
	}
	public void MoveTowards(Vector3 _Position)
	{ 
		Vector3 direction = (_Position - transform.position).normalized;
		transform.position = transform.position + direction * MovementSpeed * Time.deltaTime;


	}

	public bool IsInPlayerRange(float _Range)
	{
		if(player != null)
		{
			if(Vector3.Distance(player.position, transform.position) <= _Range)
				return true;
		}

		return false;
	}
	public bool CanAttack()
	{
		if (cooldown > 0) 
		{
			cooldown -= Time.deltaTime;
			return false;
		} 
		else 
		{
			cooldown = AttackSpeed;
			return true;
		}
	}
	public void Attack()
	{
		if (CanAttack ()) 
		{
			player.GetComponent<Player>().TakeDamage(Damage);
		}
	}
	public void Patrol()
	{
		if(Vector3.Distance(Waypoint[CurrentWaypoint].position, transform.position) <= 0.5f)
		{
			CurrentWaypoint++;
			if(CurrentWaypoint==Waypoint.Length)
				CurrentWaypoint = 0;
		}
		MoveTowards(Waypoint[CurrentWaypoint].position);
	}
    public void CollideWithObject()
    {
        
    }
	// Update is called once per frame
	void FixedUpdate () 
	{
        bla.eulerAngles = new Vector3(0,transform.rotation.eulerAngles.y,0);
        transform.rotation = bla;
		if (CanSeePlayer ()) 
		{
			Debug.DrawRay (transform.position, (player.position - transform.position).normalized * 1000, Color.red);

			if(IsInPlayerRange(AttackRange))
			{
				Attack();
			}
			else
			{
				MoveTowards (player.position);
			}
		}
		else 
		{
			Debug.DrawRay(transform.position, (player.position - transform.position).normalized*1000,Color.green);

			Patrol ();
			if(Waypoint.Length > 0) {
				for(int i = 1; i < Waypoint.Length; i++)
					Debug.DrawLine(Waypoint[i-1].transform.position,Waypoint[i].transform.position,Color.blue);
				
				Debug.DrawLine(Waypoint[Waypoint.Length-1].transform.position,Waypoint[0].transform.position, Color.blue);
			}
		}
	}
}
