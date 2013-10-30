using UnityEngine;
using System.Collections;

public class KeyboardOrbit : MonoBehaviour {
	public Transform target;
	
	private float zoomSpeed = 3.0f;
	private float minZoom = 20.0f;
	private float maxZoom = 1000.0f;
	private float cameraSpeed = 3.0f;
	
	private float z = 100.0f;
	private float x = 1.0f;
	private float y = 1.0f;
	private bool eDown = false;
	private bool qDown = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
		x -= Input.GetAxis("Horizontal") * cameraSpeed;
		y += Input.GetAxis("Vertical") * cameraSpeed;
		
		if (Input.GetKeyUp(KeyCode.Q)){
			qDown = false;
		} else if (Input.GetKeyUp(KeyCode.E)){
			eDown = false;
		}
		if (Input.GetKeyDown(KeyCode.Q) || qDown){
			qDown = true;
			z += zoomSpeed;
		} else if (Input.GetKeyDown(KeyCode.E) || eDown){
			eDown = true;
			z -= zoomSpeed;
		}
		
		if (z < minZoom){
			z = minZoom;
		} else if (z > maxZoom){
			z = maxZoom;
		}
		
		Quaternion rotation = Quaternion.Euler(y, x, 0);
		
		transform.rotation = rotation;
		transform.position = rotation * new Vector3(0, 0,  -z) + target.position;
	}
	}

