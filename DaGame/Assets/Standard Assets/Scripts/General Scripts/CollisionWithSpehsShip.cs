using UnityEngine;
using System.Collections;

public class CollisionWithSpehsShip : MonoBehaviour {

	public float damage;
	public string target = "spehsShip";
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag==target) {
			AbstractHitable sn = other.GetComponent<AbstractHitable>();
    		sn.Hit(damage);
			Destroy(gameObject);
		}
	}
}
