using UnityEngine;
using System.Collections;

abstract public class AbstractWeapon : MonoBehaviour {
	
	public float bulletSpeed;

	public abstract void shoot(Vector3 direction);
	
	public virtual void shoot(Vector3 direction, Transform target) {}
	
	public abstract void timer();
	
	
	public void shoot(GameObject target){
	}
	
	public float bulletSpeeds() {
		return bulletSpeed;
	}
	
}
