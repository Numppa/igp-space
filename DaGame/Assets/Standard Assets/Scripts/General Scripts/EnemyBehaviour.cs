using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public int health;
	public int radarVisibility;
	public GameObject[] weapons;
	public float maxFireDistance;
	
	// Update is called once per frame
	void Update () { 
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
		if (health <= 0){
			Destroy(gameObject);
		}
	}
	
	void hit(int damage){
		health -= damage;
	}
}
