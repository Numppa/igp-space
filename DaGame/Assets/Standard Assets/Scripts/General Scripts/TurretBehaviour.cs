﻿using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {
	public AbstractWeapon weapon;
	public string enemyTag;
	public float maxFireDistance;
	public float korjauskerroin = 1;
	public bool missile = false;
	
	private float angle = Mathf.PI / 4;
	public GameObject selectionIndicator;
	private Object selectionInd;
	
	private UnitManager unitManager;
	private GameObject target;
	private GameObject[] enemies;
	private float sumToY = 5;
	// Use this for initialization
	void Start () {
		
		Vector3 pos = transform.position;
		pos.y += sumToY;
		weapon = Instantiate(weapon, pos, transform.rotation) as AbstractWeapon;
		unitManager = GameObject.FindWithTag("UnitManager").GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			return;
		}
		if (unitManager.isSelected(gameObject)) {
			
		} else {
			if (selectionInd != null) {
				Destroy(selectionInd);
			}
		}
		if (target == null || targetTooFar()) {
			findNewTarget();
		}
		shoot();
	}
	
	private void findNewTarget() {
		targetEnemy(FindClosestEnemy());
	}
	
	void shoot(){
		if (target != null && !targetTooFar ()){
			if (!missile) {
				Vector3 direction = calculateDirection(target, weapon.bulletSpeed);
				weapon.shoot(direction);
			} else {
				weapon.shoot (target.transform.position, target.transform);
			}
			
		}
	}
	
	private bool targetTooFar() {
		return target.transform.position.sqrMagnitude > maxFireDistance;
	}
	
	void clicked() {
		
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
			unitManager.selectAdditionalUnit(gameObject);
			if (selectionInd == null) {
				selectionInd = Instantiate(selectionIndicator, transform.position, transform.rotation) as GameObject;
			}
		} else {
			unitManager.selectSingleUnit(gameObject);
			if (selectionInd == null) {
				selectionInd = Instantiate(selectionIndicator, transform.position, transform.rotation) as GameObject;
			}
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
        //GameObject closest = enemies[0];
		GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies) {
			if (enemyInSector(enemy.transform.position)) {
				Vector3 difference = enemy.transform.position - position;
            	float currentDistance = difference.sqrMagnitude;
            	if (currentDistance < distance) {
            	    closest = enemy;
            	    distance = currentDistance;
            	}
			}
            
        }
        return closest;
    }
			
	private bool enemyInSector(Vector3 enemyPosition) {
		Vector3 addVector = new Vector3(0, transform.position.magnitude, 0);
		Vector3 middleSector = transform.position + addVector;
		if (Vector3.Dot (middleSector.normalized, enemyPosition.normalized) > Mathf.Cos (angle)) {
			return true;
		} else {
			return false;
		}
	}
	
	private Vector3 calculateDirection(GameObject target, float bulletSpeed) {
		Vector3 direction = target.transform.position - transform.position;
		direction.y -= sumToY;
		//direction += closest.rigidbody.velocity * (direction.magnitude / (bulletSpeed - closest.rigidbody.velocity.magnitude));
		
		float speedDifference = Mathf.Pow (bulletSpeed, 2) / target.rigidbody.velocity.sqrMagnitude - 1;
		float angleEffect = Vector3.Project (direction, target.rigidbody.velocity).magnitude;
		float distanceEffect = direction.sqrMagnitude;
		float sqrtThing = Mathf.Sqrt(Mathf.Pow (angleEffect, 2) + 
				speedDifference * distanceEffect);
		float theThing = 0;
		if (sqrtThing > angleEffect) {
			theThing = ((angleEffect - sqrtThing) / speedDifference);
		} else {
			theThing = -((angleEffect + sqrtThing) / speedDifference);
		}
		
		direction -= target.rigidbody.velocity.normalized * theThing;
		
		//direction += closest.rigidbody.velocity * (direction.magnitude / Mathf.Sqrt(Mathf.Pow (bulletSpeed, 2) - closest.rigidbody.velocity.sqrMagnitude));
		
		return direction;
	}
}
