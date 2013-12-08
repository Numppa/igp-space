using UnityEngine;
using System.Collections;

public class DetectClicks : MonoBehaviour {	
	
	private GameObject[] enemies;
	//This variable adds a Debug.Log call to show what was touched
	public bool debug = false;
	
	//This is the actual camera we reference in the update loop, set in Start()
	private Camera _camera;
	
	private UnitManager unitManager;
	
	
	void Start() {
		unitManager = GameObject.FindWithTag("UnitManager").GetComponent<UnitManager>();
		
		_camera = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray;
		RaycastHit hit;
		
		
		if(Input.GetMouseButtonDown(0))  {
			ray = _camera.ScreenPointToRay(Input.mousePosition); 
				
			if(Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if(debug) {
					Debug.Log("You left clicked " + hit.collider.gameObject.name,hit.collider.gameObject);
				}
				
				hit.transform.gameObject.SendMessageUpwards("clicked", hit.point, SendMessageOptions.DontRequireReceiver);
			}		
		}
		
		if(Input.GetMouseButtonDown(1))  {
			ray = _camera.ScreenPointToRay(Input.mousePosition); 
				
			if(Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				if(debug) {
					Debug.Log("You right clicked " + hit.collider.gameObject.name,hit.collider.gameObject);
				}
				GameObject enemy = FindClosestEnemy(hit.point);
				if(!enemy){
					return;
				}
				foreach(GameObject unit in unitManager.getSelectedUnits()) {
					unit.transform.gameObject.SendMessageUpwards("targetEnemy", enemy, SendMessageOptions.DontRequireReceiver);
				}
			}		
		}
	}
	
		private GameObject FindClosestEnemy(Vector3 point) {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
		if (enemies.Length == 0) {
			return null;
		}
        //GameObject closest = enemies[0];
		GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject enemy in enemies) {
				Vector3 difference = enemy.transform.position - point;
            	float currentDistance = difference.sqrMagnitude;
            	if (currentDistance < distance) {
            	    closest = enemy;
            	    distance = currentDistance;
			}
            
        }
        return closest;
    }
	
	
}

