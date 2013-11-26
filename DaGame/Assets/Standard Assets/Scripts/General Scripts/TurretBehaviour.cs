using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {
	public AbstractWeapon weapon;
	private bool selected;
	
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			renderer.material.color = Color.blue;
		} else {
			if (renderer.material.color == Color.blue) {
				renderer.material.color = Color.white;
			}
		}
	}
	
	void shoot(){
		weapon.shoot(transform.forward);
	}
	
	void clicked() {
		selected = true;	
	}
	
	void deSelect() {
	 	selected = false;	
	}
	
	GameObject findClosestEnemy(){
		return null; 
	}
}
