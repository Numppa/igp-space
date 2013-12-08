using UnityEngine;
using System.Collections;

public class LaserWeapon : AbstractWeapon {
	public int weaponRestTime;
	public float weaponShootTime;
	public LaserBeam beam;
	
	
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
	}
	
	public override void shoot (Vector3 direction, Transform target) {
		if (shootTime > 0){
			shootTime -= 1.0f;
			LaserBeam shootedBeam = Instantiate(beam, transform.position , transform.rotation) as LaserBeam;
			shootedBeam.target = target;
		
			if (shootTime <= 0){
				restTime = weaponRestTime;
			}
		}
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
