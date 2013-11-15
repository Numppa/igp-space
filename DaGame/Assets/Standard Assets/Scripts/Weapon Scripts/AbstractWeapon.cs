using UnityEngine;
using System.Collections;

abstract public class AbstractWeapon : MonoBehaviour {

	public abstract void shoot(Vector3 direction);
	public abstract void timer();
	
}
