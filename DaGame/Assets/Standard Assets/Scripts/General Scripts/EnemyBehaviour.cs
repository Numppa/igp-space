using UnityEngine;
using System.Collections;

public class EnemyBehaviour : AbstractHitable {
	public float health;
	public int radarVisibility;
	public GameObject[] weapons;
	public float maxFireDistance;
	public GameObject explosion;
	public int bounty;
	public GameObject soundObject;
	
	// Update is called once per frame
	void Update () { 
		if (Time.timeScale == 0) {
			return;
		}
		foreach (GameObject w in weapons) {
				AbstractWeapon aw = w.GetComponent<AbstractWeapon>();
				if (aw != null) {
					if (transform.position.sqrMagnitude < maxFireDistance) {
						Vector3 direction = transform.position;
						direction *= -1;
						aw.shoot(direction);
					}
					aw.timer ();
				}
		}

	}
	
	public override void Hit(float damage){
		health -= damage;
		if (health <= 0){
			collider.enabled = false;
			GameObject explo = (GameObject) Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
			GameObject sound = (GameObject) Instantiate(soundObject, gameObject.transform.position, gameObject.transform.rotation);
			Destroy(gameObject);
			GameObject.FindWithTag("spehsShip").BroadcastMessage("ChangeResources", bounty);
			Destroy(explo, 3);
		}
	}
}
