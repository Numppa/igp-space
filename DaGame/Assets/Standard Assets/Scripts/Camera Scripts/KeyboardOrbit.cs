using UnityEngine;
using System.Collections;

public class KeyboardOrbit : MonoBehaviour {
	public Transform target;
	private float zoomSpeed;
	private float minZoom;
	private float maxZoom;
	private float cameraSpeed;
	private float z;
	private float x;
	private float y;
	private bool eDown;
	private bool qDown;
	// Use this for initialization
	void Start (){
		zoomSpeed = 2.0f;
		minZoom = 200.0f;
		maxZoom = 600.0f;
		cameraSpeed = 1.5f;
		
		z = 300.0f;
		x = 1.0f;
		y = 1.0f;
		eDown = false;
		qDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		x -= Input.GetAxis ("Horizontal") * cameraSpeed;
		y += Input.GetAxis ("Vertical") * cameraSpeed;
		
		updateZoom();
		
		Quaternion rotation = Quaternion.Euler (y, x, 0);
		
		transform.rotation = rotation;
		transform.position = rotation * new Vector3 (0, 0, -z) + target.position;
	}

	void updateZoom () {
		if (Input.GetKeyUp (KeyCode.Q)) {
			qDown = false;
		} else if (Input.GetKeyUp (KeyCode.E)) {
			eDown = false;
		}
		if (Input.GetKeyDown (KeyCode.Q) || qDown) {
			qDown = true;
			z += zoomSpeed;
		} else if (Input.GetKeyDown (KeyCode.E) || eDown) {
			eDown = true;
			z -= zoomSpeed;
		}
		
		if (z < minZoom) {
			z = minZoom;
		} else if (z > maxZoom) {
			z = maxZoom;
		}
	}
}