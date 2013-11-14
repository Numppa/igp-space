using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int health;
	public int radarVisibility;
	public Weapon[] weapons;
	
	public Rigidbody bullet;
	public float bulletSpeed;
	public float maxFireDistance;
	public int weaponRestTime;
	private int restTime;
	// Use this for initialization
	void Start () {
		restTime = weaponRestTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (restTime > 0) {
			restTime--;
		} else if (transform.position.sqrMagnitude < maxFireDistance) {
			restTime = weaponRestTime;
			GameObject shootedBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			Vector3 direction = transform.position;
			direction.Normalize();
			direction *= -1 * bulletSpeed;
			shootedBullet.rigidbody.velocity = direction;
		}
		if (health <= 0){
			Destroy(gameObject);
		}
	}
	
	void hit(int damage){
		health -= damage;
	}
	
	void shoot(GameObject target){
		foreach (Weapon w in weapons){
			w.shoot(transform.forward, target);
		}
	}
}
