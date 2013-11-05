using UnityEngine;
using System.Collections;

public class PlaneObject : MonoBehaviour {
	
	private bool hasTurret = false;
	private bool selected = false;
	public static PlaneObject selection;
	
	void Update() {
		if(selection != this) {
			selected = false;
		}
		if (selected == false && renderer.material.color == Color.blue) {
			renderer.material.color = Color.white;	
		}
		
	}

	void OnMouseEnter() {
		if (!hasTurret && !selected) {
			
    		renderer.material.color = Color.green;
			
		} 
	}

	void OnMouseExit() {
   		if (!hasTurret && !selected) {
			renderer.material.color = Color.white;
		}
	}
	
	void OnMouseDown() {
		if (!selected && renderer.isVisible && !hasTurret) {
			renderer.material.color = Color.blue;
			selected = true;
			selection = this;
		} else {
			
			renderer.material.color = Color.white;
			selected = false;
			
		
		}		
		
	}
	
	void OnGUI() {
		if(selected) {
			Rect rect = new Rect(Screen.width-220, 10, 180, Screen.height / 1.3f);
			GUI.Box(rect, "WORKSHOP\n\n"+this.gameObject.name);
		}
	}
}
