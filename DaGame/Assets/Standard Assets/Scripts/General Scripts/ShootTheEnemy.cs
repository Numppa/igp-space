using UnityEngine;
using System.Collections;

public class ShootTheEnemy : MonoBehaviour {
	
	public string enemyTag;
	public float korjauskerroin = 1;
	
	public GameObject[] weapons;
	public float maxFireDistance;
	
	private GameObject FindClosestEnemy() {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		if (enemies.Length == 0) {
			return null;
		}
        GameObject closest = enemies[0];
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies) {
            Vector3 difference = enemy.transform.position - position;
            float currentDistance = difference.sqrMagnitude;
            if (currentDistance < distance) {
                closest = enemy;
                distance = currentDistance;
            }
        }
        return closest;
    }
	
	private Vector3 calculateDirection(GameObject closest, float bulletSpeed) {
		Vector3 direction = closest.transform.position - transform.position;
		direction += closest.rigidbody.velocity * (direction.magnitude / (bulletSpeed - closest.rigidbody.velocity.magnitude));
		return direction;
	}
	
	// Update is called once per frame
	public void timer () { 
		foreach (GameObject w in weapons) {
			AbstractWeapon aw = w.GetComponent<AbstractWeapon>();
			if (aw != null) {
				GameObject closest = FindClosestEnemy();
				if (closest == null) {
					continue;
				}
				if (closest.transform.position.sqrMagnitude < maxFireDistance) {
					Vector3 direction = calculateDirection(closest, aw.bulletSpeeds());
					aw.shoot(direction);
				}
				aw.timer ();
			}
		}
	}
}
