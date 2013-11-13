using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {
	public Weapon weapon;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void shoot(GameObject target){
		weapon.shoot(transform.forward, target);
	}
}
