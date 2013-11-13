using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public int timeBetweenEnemies;
	public int timeBetweenWaves;
	private int timer;
	public GameObject[] wave0;
	public GameObject[] wave1;
	private int index = 0;
	private int wave = 0;
	
	// Use this for initialization
	void Start () {
		timer = timeBetweenEnemies;
		for (int i = 0; i < wave1.Length; i++) {
			if(wave1[i].activeSelf == true) {
				wave1[i].SetActive (false);
			}
		}
		for (int i = 0; i < wave0.Length; i++) {
			if(wave0[i].activeSelf == true) {
				wave0[i].SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer--;
		} else {
			if (wave == 0) {
				activateEnemy(wave0);
			} else if (wave == 1) {
				activateEnemy(wave1);
			}
		}
	}
	
	private void activateEnemy(GameObject[] waveNumber) {
		if (waveNumber[index].activeSelf == false) {
			waveNumber[index].SetActive (true);
			if (index < wave1.Length -1) {
				index++;
				timer = timeBetweenEnemies;
			} else {
				index = 0;
				timer = timeBetweenWaves;
				wave++;
			}
		}
	}
}
