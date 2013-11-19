using UnityEngine;
using System.Collections;

public class CollisionWithEnemy : MonoBehaviour {

	public float damage;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="enemy") {
    		other.SendMessage("hit", damage);
			Destroy(gameObject);
		}
	}
}
