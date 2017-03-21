using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

	GameObject player;
	GameObject inventory;
	public float throwForce = 200;

	void Start() {
		player = GameObject.Find("Player");
		inventory = GameObject.Find("Inventory");
	}
	
	public void pickup () {
		GetComponent<Rigidbody>().isKinematic = true;
		transform.position = inventory.transform.position;
		transform.parent = inventory.transform;
	}

	public void drop() {
		GetComponent<Rigidbody> ().isKinematic = false;
		transform.parent = null;
		GetComponent<Rigidbody> ().AddForce (inventory.transform.forward * throwForce);
	}
}
