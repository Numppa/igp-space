using UnityEngine;

using System.Collections;



public class MenuObject : MonoBehaviour {

	// Use this for initialization



  
	public int level = 0;

  
	void OnMouseEnter() {

    	renderer.material.color = Color.blue;

  
	}



	void OnMouseExit() {

   
		renderer.material.color = Color.white;
  
  
	}



	void OnMouseDown() {
		
    
		if(level==99) {
      
			Application.Quit();
    
		} else if (level == 50) {
			    TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
			
			if (t.text == "Sound: Off") {
				t.text = "Sound: On";
				AudioListener.pause = false;
			} else {
				t.text = "Sound: Off";
				AudioListener.pause = true;
			}
		} else {
      
			Application.LoadLevel(level);
    
		}
  
  
	}

}
