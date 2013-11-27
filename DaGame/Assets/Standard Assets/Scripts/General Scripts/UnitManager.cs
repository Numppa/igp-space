using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {
	
	public List<GameObject> selectedUnits;
	
	// Use this for initialization
	void Start () {
		selectedUnits.Clear();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool isSelected(GameObject unit) {
		return selectedUnits.Contains(unit);
	}
	
	public void selectSingleUnit(GameObject unit) {
		selectedUnits.Clear();
		selectedUnits.Add(unit);
	}
	
	public void selectAdditionalUnit(GameObject unit) {
		selectedUnits.Add(unit);
	}
	
	public void deselectAllUnits() {
		selectedUnits.Clear();	
	}
	
	public List<GameObject> getSelectedUnits() {
		return selectedUnits;
	}
	
}
