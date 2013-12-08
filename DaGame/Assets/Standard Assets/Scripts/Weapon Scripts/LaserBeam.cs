using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]

public class LaserBeam : MonoBehaviour {
	
	public float width;
	public float length;
	public Color color;
	
	
	private LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetWidth(width, width);
		lineRenderer.SetColors(color, color);
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
