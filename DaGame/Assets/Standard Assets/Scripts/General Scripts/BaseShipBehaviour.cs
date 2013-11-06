using UnityEngine;
using System.Collections;

public class BaseShipBehaviour : MonoBehaviour {
	public Transform target;
	public float maxHealth;
	public float repair;
	public static float resources;
	
	private float health;
	
	// Use this for initialization
	void Start () {
		maxHealth = 1000.0f;
		repair = -0.0f;
		resources = 150f;
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		health += repair;
	}

	void OnGUI(){
		GUI.contentColor = Color.green;
		GUI.Box(new Rect(10, 10, Screen.width / 2, 20),new GUIContent("Resources: " + resources + "   Health: " + (int) health + " / " + (int) maxHealth));
	}
	
	void ChangeResources(int amount) {
	 	resources +=amount;	
	}
	
}
