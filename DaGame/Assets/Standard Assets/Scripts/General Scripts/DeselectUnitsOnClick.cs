using UnityEngine;
using System.Collections;

public class DeselectUnitsOnClick : MonoBehaviour {
	
	private UnitManager unitManager;
	
	void Start () {
		unitManager = GameObject.FindWithTag("UnitManager").GetComponent<UnitManager>();
	}
	
	
	void Update () {
	
	}
	
	void clicked() {
		unitManager.deselectAllUnits();	
	}
}
