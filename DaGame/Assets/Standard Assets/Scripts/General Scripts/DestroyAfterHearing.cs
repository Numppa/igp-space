using UnityEngine;
using System.Collections;

public class DestroyAfterHearing : MonoBehaviour {
	public AudioClip clip;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, clip.length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
