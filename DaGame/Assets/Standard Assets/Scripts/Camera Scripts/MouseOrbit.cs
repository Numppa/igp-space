using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour {
	public Transform target;
	public float zoomSpeed;
	public float minZoom;
	public float maxZoom;
	public float cameraSpeed;
	private float z;
	private float x;
	private float y;
	// Use this for initialization
	void Start (){
		z = 300.0f;
		x = 1.0f;
		y = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButton(2)) {
			x += Input.GetAxis ("Mouse X") * cameraSpeed;
			y -= Input.GetAxis ("Mouse Y") * cameraSpeed;
		}
		
		z -= Input.GetAxisRaw("Mouse ScrollWheel")*zoomSpeed;
		
		if (z < minZoom) {
			z = minZoom;
		} else if (z > maxZoom) {
			z = maxZoom;
		}
		
		Quaternion rotation = Quaternion.Euler (y, x, 0);
		
		transform.rotation = rotation;
		transform.position = rotation * new Vector3 (0, 0, -z) + target.position;
		
	}

}