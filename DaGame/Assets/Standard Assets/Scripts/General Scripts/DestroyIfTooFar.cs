using UnityEngine;
using System.Collections;

public class DestroyIfTooFar : MonoBehaviour {
	
	public int distance;
	
	private float lastPosition;
	private int timer;
	// Use this for initialization
	void Start () {
		lastPosition = transform.position.sqrMagnitude;
		timer = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.sqrMagnitude > distance) {
			Destroy (gameObject);
		}
		if (lastPosition - transform.position.sqrMagnitude < 4 && lastPosition - transform.position.sqrMagnitude > -4 && timer < 1) {
			Destroy (gameObject);
		} else if (timer > -3) {
			timer--;
		} else {
			lastPosition = transform.position.sqrMagnitude;
			timer = 3;
		}
	}
}
