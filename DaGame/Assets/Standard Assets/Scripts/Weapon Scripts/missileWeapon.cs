using UnityEngine;
using System.Collections;

public class missileWeapon : AbstractWeapon {
	public bool friendly;
	public int weaponRestTime = 200;
	public int shotsBeforeReload = 5;
	public Rigidbody missile;
	public int waitTimeBeforeNextMissile = 50;
	
	private int nextMissile;
	private int shots;
	private int restTime;
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		nextMissile = waitTimeBeforeNextMissile;
		restTime = weaponRestTime;
		shots = shotsBeforeReload;
	}
	
	// Update is called once per frame
	void Update () {
		timer();
	}
	
	public override void shoot (Vector3 direction, Transform target) {
		if (restTime <= 0 && nextMissile <= 0){
			shots--;
			if (shots <= 0){
				shots = shotsBeforeReload;
				restTime = weaponRestTime;
			}
			Rigidbody shootedMissile = Instantiate(missile, transform.position, transform.rotation) as Rigidbody;
			
			SeekSteer ss = shootedMissile.GetComponent<SeekSteer>();
			ss.waypoints[0] = target;
			
			direction.Normalize();
			direction *= bulletSpeed;
			shootedMissile.velocity = direction;
		}
	}
	
	public override void shoot(Vector3 direction) {}

	public override void timer () {
		if (restTime > 0){
			restTime--;
		} else if (nextMissile > 0){
			nextMissile--;
		}
	}
}
