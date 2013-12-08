using UnityEngine;
using System.Collections;


public class LaserBeam : MonoBehaviour {
	
	public LineRenderer lineRenderer;
	public Transform target;
	public int aliveCount;
	public float damage;
	
	
	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetPosition(0, transform.position);
		lineRenderer.SetPosition(1, target.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (aliveCount > 0){
			aliveCount--;
		} else {
			if (target){
				target.SendMessage("Hit", damage);
			}
			Destroy(gameObject);
		}
	}
	
}
