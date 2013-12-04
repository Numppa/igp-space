﻿using UnityEngine;
using System.Collections;

public class GatlingWeapon : AbstractWeapon {
	public bool friendly;
	public int weaponRestTime;
	public int shotsBeforeReload;
	public Rigidbody bullet;
	public int waitTimeBeforeNextBullet;
	
	private int nextBullet;
	private int shots;
	private int restTime;
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		nextBullet = waitTimeBeforeNextBullet;
		restTime = weaponRestTime;
		shots = shotsBeforeReload;
	}
	
	// Update is called once per frame
	void Update () {
		timer();
	}
	
	public override void shoot (Vector3 direction) {
		if (restTime <= 0 && nextBullet <= 0){
			shots--;
			if (shots <= 0){
				shots = shotsBeforeReload;
				restTime = weaponRestTime;
			}
			Rigidbody shootedBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
			
			direction.Normalize();
			direction *= bulletSpeed;
			shootedBullet.velocity = direction;
		}
	}

	public override void timer () {
		if (restTime > 0){
			restTime--;
		} else if (nextBullet > 0){
			nextBullet--;
		}
	}
}
