using UnityEngine;
using System.Collections;

public class BaseShipBehaviour : AbstractHitable {	
	public float maxHealth;
	public float repair;
	public static float resources;
	
	private float health;
	
	// Use this for initialization
	void Start () {
		renderer.material.color = Color.white;
		maxHealth = 1000.0f;
		repair = -0.0f;
		resources = 150f;
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		health += repair;
		ShootTheEnemy ste = gameObject.GetComponent<ShootTheEnemy>();
		ste.timer ();
		if (Input.GetKey("escape")) {
			Application.Quit();
		}
	}

	void OnGUI(){
		GUI.contentColor = Color.green;
		GUI.Box(new Rect(10, 10, Screen.width / 2, 20),new GUIContent("Resources: " + resources + "   Health: " + (int) health + " / " + (int) maxHealth));
	}
	
	void ChangeResources(int amount) {
	 	resources +=amount;	
	}
	
	public static float getResources() {
		return resources;	
	}
	
	public override void Hit(float damage) {
		health -= damage;
	}
	
}
