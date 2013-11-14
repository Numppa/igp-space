using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {
	public Weapon[] weapons;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void shoot(GameObject target){
		foreach (Weapon w in weapons){
			w.shoot(transform.forward, target);
		}
	}
}
