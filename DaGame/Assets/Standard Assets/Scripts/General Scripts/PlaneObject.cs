﻿using UnityEngine;
using System.Collections;

public class PlaneObject : MonoBehaviour {
	
	private bool hasTurret = false;
	private bool selected = false;
	private int guiSelection = 0;
	public static PlaneObject selection;
	public GameObject[] turrets;
	public Texture[] images;
	
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
			
			string[] asd = {"GT","none","none","none","none","none","none","none","none"};
			GUI.contentColor = Color.green;
			Rect rect = new Rect(Screen.width-220, 10, 180, Screen.height / 1.3f);
			Rect rectInside = new Rect(Screen.width-215, Screen.height / 7f, 170, Screen.height / 2.4f);
			Rect rectBelow = new Rect(Screen.width-215, Screen.height / 1.75f, 170, Screen.height / 6f);
			Rect rectButton = new Rect(Screen.width-215, Screen.height / 1.35f, 85, Screen.height / 24f);
			GUI.Box(rect, "WORKSHOP\n\n"+this.gameObject.name);
			
			if (guiSelection == 0) {
			   	GUI.TextArea(rectBelow,"Info:");
				bool buying = GUI.Button(rectButton, "Buy");
				
				if (buying && BaseShipBehaviour.resources >= 50) {
					Instantiate(turrets[guiSelection], gameObject.transform.position, gameObject.transform.rotation);
					BaseShipBehaviour.resources -= 50;
					selected = false;
					hasTurret = true;
				}
				
			} else {
			 	
			}
			
			GUI.Box(rectInside, "");
			guiSelection = GUI.SelectionGrid(rectInside, guiSelection, images, 3);
			
						
		}
	}
}
