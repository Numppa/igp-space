using UnityEngine;
using System.Collections;

public class TurretBehaviour : MonoBehaviour {
	public AbstractWeapon weapon;
	private UnitManager unitManager;
	private GameObject target;
	
	private GameObject[] enemies;
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("enemy");
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
	}
	
	void shoot(){
		weapon.shoot(transform.forward);
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
	
	
	GameObject findClosestEnemy(){
		return null; 
	}
}
