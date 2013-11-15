using UnityEngine;
using System.Collections;

public class AllaroundWeapon : AbstractWeapon {
	
	public Rigidbody bullet;
	public float bulletSpeed;
	public int weaponRestTime;
	private int restTime;
	
	// Use this for initialization
	void Start () {
		restTime = weaponRestTime;
	}
	
	public override void timer () {
		if (restTime > 0) {
			restTime--;
		}
	}
	
	public override void shoot(Vector3 direction) {
		if (restTime <= 0) {
			restTime = weaponRestTime;
			Rigidbody shootedBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
			
			direction.Normalize();
			direction *= bulletSpeed;
			shootedBullet.velocity = direction;
		}
	}
}
