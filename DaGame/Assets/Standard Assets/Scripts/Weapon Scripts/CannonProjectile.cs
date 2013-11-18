using UnityEngine;
using System.Collections;

public class CannonProjectile : MonoBehaviour {
	public int damage;
	public float speedMultiplier;
	public float acceleration;
	public Vector3 speed;
	
	// Use this for initialization
	void Start () {
		speed *= speedMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
		speed *= acceleration;
	}


}
