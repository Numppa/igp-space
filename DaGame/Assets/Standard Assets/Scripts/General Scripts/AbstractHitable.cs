using UnityEngine;
using System.Collections;

abstract public class AbstractHitable : MonoBehaviour {

	public abstract void Hit(float damage);
	
}
