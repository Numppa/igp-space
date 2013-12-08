using UnityEngine;
using System.Collections;

public class LaserWeapon : AbstractWeapon {
	public int weaponRestTime;
	public float weaponShootTime;
	
	
	private int restTime;
	private float shootTime;
	// Use this for initialization
	void Start () {
		restTime = 0;
		shootTime = weaponShootTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer();
	}
	
	public override void shoot (Vector3 direction) {
		weaponShootTime -= 1;
	}
	
	public override void timer () {
		if (restTime > 0){
			restTime--;
			if (restTime <= 0){
				shootTime = weaponShootTime;
			}
		} else if (shootTime < weaponShootTime){
			shootTime += 0.25f;
		}
	}
}
