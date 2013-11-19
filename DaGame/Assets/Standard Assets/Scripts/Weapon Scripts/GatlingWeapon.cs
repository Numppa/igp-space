using UnityEngine;
using System.Collections;

public class GatlingWeapon : AbstractWeapon {
	public bool friendly;
	public int weaponRestTime;
	public int shotsBeforeReload;
	public Rigidbody bullet;
	
	private int shots;
	private int restTime;
	// Use this for initialization
	void Start () {
		restTime = weaponRestTime;
		shots = shotsBeforeReload;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public override void shoot (Vector3 direction) {
		if (restTime <= 0){
			shots--;
			if (shots <= 0){
				shots = shotsBeforeReload;
				restTime = weaponRestTime;
			}
			Rigidbody shooted = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
		}
	}

	public override void timer () {
		if (restTime > 0){
			restTime--;
		}
	}
}
