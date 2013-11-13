﻿using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int health;
	public int radarVisibility;
	public Weapon weapon;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0){
			Destroy(gameObject);
		}
	}
	
	void hit(int damage){
		health -= damage;
	}
	
	void shoot(GameObject target){
		weapon.shoot(transform.forward, target);
	}
}
