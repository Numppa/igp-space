using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public int timeBetweenWaves;
	private int timer;
	public GameObject[] waves;
	private int wave = 0;
	
	// Use this for initialization
	void Start () {
		timer = timeBetweenWaves;
		foreach (GameObject enemy in waves) {
			if(enemy.activeSelf == true) {
				enemy.SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer--;
		} else {
			waves[wave].SetActive (true);
			if (waves.Length >= wave + 2) {
				timer = timeBetweenWaves;
				wave++;
			}
		}
	}
}
