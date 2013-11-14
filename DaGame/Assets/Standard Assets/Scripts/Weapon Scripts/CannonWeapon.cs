using UnityEngine;
using System.Collections;

public class CannonWeapon : MonoBehaviour {
	public int cooldowntime;
	public bool friendly;
	
	private int cooldown;
	// Use this for initialization
	void Start () {
		cooldown = cooldowntime;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown < cooldowntime){
			cooldown++;
		}
	}
	
	public void shoot(Vector3 direction, GameObject target){
		if (cooldown >= cooldowntime){
		}
	}
}
