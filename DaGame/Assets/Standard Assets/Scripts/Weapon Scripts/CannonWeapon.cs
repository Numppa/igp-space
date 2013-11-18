using UnityEngine;
using System.Collections;

public class CannonWeapon : AbstractWeapon {
	public bool friendly;
	public int weaponRestTime;
	
	private int restTime;
	// Use this for initialization
	void Start () {
		restTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public override void shoot (Vector3 direction) {
		if (restTime <= 0){
		}
		restTime = weaponRestTime;
	}

	public override void timer () {
		if (restTime > 0){
			restTime--;
		}
	}
}
