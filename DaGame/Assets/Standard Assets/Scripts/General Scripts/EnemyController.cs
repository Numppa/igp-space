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
		if (timer > 0 && (wave == 0 || !waves[wave-1].activeSelf)) {
			timer--;
		} else if (timer <= 0) {
			waves[wave].SetActive (true);
			if (waves.Length >= wave + 2) {
				timer = timeBetweenWaves;
				wave++;
			}
		} else if (wave != 0) {
			int count = 0;
			foreach (Transform child in waves[wave-1].transform) {
				count++;
			}
			if (count == 0) {
				waves[wave-1].SetActive(false);
			}
		}
	}
}
