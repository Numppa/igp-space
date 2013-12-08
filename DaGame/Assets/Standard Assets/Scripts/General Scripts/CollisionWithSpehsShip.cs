using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CollisionWithSpehsShip : MonoBehaviour {

	public float damage;
	public string target = "spehsShip";
	public AudioClip hitSound;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag==target) {
			AbstractHitable sn = other.GetComponent<AbstractHitable>();
    		sn.Hit(damage);
			audio.PlayOneShot(hitSound);
			renderer.enabled = false;
			collider.enabled = false;
			Destroy(gameObject, hitSound.length);
		}
	}
}
