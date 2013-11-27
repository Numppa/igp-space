using UnityEngine;
using System.Collections;

public class DetectClicks : MonoBehaviour {	
	
	
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
				foreach(GameObject unit in unitManager.getSelectedUnits()) {
					unit.transform.gameObject.SendMessage("targetEnemy", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}		
		}
	}
	
	
}

