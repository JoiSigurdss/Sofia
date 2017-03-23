using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {

	GameObject player;
	GameObject inventory;
	GameObject fpsCamera;
	public float weight; // coin is 1, heavy rock is 10

	void Start() {
		player = GameObject.Find("Player");
		fpsCamera = GameObject.Find("FPSCamera");
		inventory = GameObject.Find("Inventory");
	}

	public void pickup () {
		GetComponent<Rigidbody>().isKinematic = true;
		transform.position = inventory.transform.position;
		transform.parent = inventory.transform;
	}

	public void drop(float throwForce) {
		GetComponent<Rigidbody> ().isKinematic = false;
		transform.parent = null;
		//Debug.Log (inventory.GetComponent<Rigidbody> ().velocity);
		GetComponent<Rigidbody> ().AddForce (fpsCamera.transform.forward * throwForce);
	}
}
