using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public GUIText youWin;
	public float youWinDelay = 3.0f;
	public int timeBetweenWaves;
	private int timer;
	public GameObject[] waves;
	private int wave = 0;
	
	
	// Use this for initialization
	void Start () {
		youWin.enabled = false;
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
		} else if (timer == 0) {
			waves[wave].SetActive (true);
			if (waves.Length >= wave + 1) {
				timer = timeBetweenWaves;
				wave++;
				if (wave == waves.Length) {
					timer = -1;
				}
			}
			
			
		} else if (wave != 0) {
			int count = 0;
			foreach (Transform child in waves[wave-1].transform) {
				count++;
			}
			if (count == 0) {
				waves[wave-1].SetActive(false);
				if (wave == waves.Length) {
					youWin.enabled = true;
					Invoke("end", youWinDelay);
				}
			}
		}
		
	}
	
	private void end() {
		Application.LoadLevel(0);
	}
}
