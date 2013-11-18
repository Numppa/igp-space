using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {
	public AbstractWeapon weapon;
	
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("enemy");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void shoot(){
		weapon.shoot(transform.forward);
	}
	
	GameObject findClosestEnemy(){
		return null; 
	}
}
