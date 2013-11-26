using UnityEngine;
using System.Collections;

public class DetectClicks : MonoBehaviour {	
	
	
	//This variable adds a Debug.Log call to show what was touched
	public bool debug = false;
	
	//This is the actual camera we reference in the update loop, set in Start()
	private Camera _camera;
	
	void Start() {
		
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
					Debug.Log("You clicked " + hit.collider.gameObject.name,hit.collider.gameObject);
				}
				
				hit.transform.gameObject.SendMessage("clicked", hit.point, SendMessageOptions.DontRequireReceiver);
			}		
		}
	}
	
}

