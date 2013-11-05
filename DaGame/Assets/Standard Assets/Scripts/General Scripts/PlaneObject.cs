using UnityEngine;
using System.Collections;

public class PlaneObject : MonoBehaviour {
	
	private bool hasTurret = false;

	void OnMouseEnter() {
		if (!hasTurret) {	
    		renderer.material.color = Color.green;
		}
	}



	void OnMouseExit() {
   		if (!hasTurret) {
			renderer.material.color = Color.white;
		}
	}
	
	void OnMouseDown() {
		
		
	}
}
