using UnityEngine;
using System.Collections;

public class CollisionWithSpehsShip : MonoBehaviour {

	public float damage;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="spehsShip") {
			BaseShipBehaviour sn = other.GetComponent<BaseShipBehaviour>();
    		sn.Hit(damage);
			Destroy(gameObject);
		}
	}
}
