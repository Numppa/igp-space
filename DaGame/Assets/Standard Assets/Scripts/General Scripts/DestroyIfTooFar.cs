using UnityEngine;
using System.Collections;

public class DestroyIfTooFar : MonoBehaviour {
	
	public int distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.sqrMagnitude > distance) {
			Destroy (gameObject);
		}
	}
}
