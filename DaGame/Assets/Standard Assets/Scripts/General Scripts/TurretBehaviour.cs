using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {
	public AbstractWeapon weapon;
	public string enemyTag;
	public float maxFireDistance;
	public float korjauskerroin = 1;
	
	private UnitManager unitManager;
	private GameObject target;
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		Vector3 pos = transform.position;
		pos.y += 5;
		weapon = Instantiate(weapon, pos, transform.rotation) as AbstractWeapon;
		unitManager = GameObject.FindWithTag("UnitManager").GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (unitManager.isSelected(gameObject)) {
			renderer.material.color = Color.blue;
		} else {
			if (renderer.material.color == Color.blue) {
				renderer.material.color = Color.white;
			}
		}
		shoot();
	}
	
	void shoot(){
		GameObject closestEnemy = FindClosestEnemy();
		if (closestEnemy != null && closestEnemy.transform.position.sqrMagnitude < maxFireDistance){
			Vector3 direction = calculateDirection(closestEnemy, weapon.bulletSpeed);
			weapon.shoot(direction);
		}
	}
	
	void clicked() {
		
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
			unitManager.selectAdditionalUnit(gameObject);
		} else {
			unitManager.selectSingleUnit(gameObject);
		}
	
	}
	
	void targetEnemy(GameObject enemy) {
		target = enemy;
	}
	
	
	private GameObject FindClosestEnemy() {
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
		
		//direction += closest.rigidbody.velocity * (direction.magnitude / (bulletSpeed - closest.rigidbody.velocity.magnitude));
		
		float speedDifference = Mathf.Pow (bulletSpeed, 2) / closest.rigidbody.velocity.sqrMagnitude - 1;
		float angleEffect = Vector3.Project (direction, closest.rigidbody.velocity).magnitude;
		float distanceEffect = direction.sqrMagnitude;
		float sqrtThing = Mathf.Sqrt(Mathf.Pow (angleEffect, 2) + 
				speedDifference * distanceEffect);
		float theThing = 0;
		if (sqrtThing > angleEffect) {
			theThing = ((angleEffect - sqrtThing) / speedDifference);
		} else {
			theThing = -((angleEffect + sqrtThing) / speedDifference);
		}
		
		direction -= closest.rigidbody.velocity.normalized * theThing;
		
		//direction += closest.rigidbody.velocity * (direction.magnitude / Mathf.Sqrt(Mathf.Pow (bulletSpeed, 2) - closest.rigidbody.velocity.sqrMagnitude));
		
		return direction;
	}
}
