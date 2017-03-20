using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	public float pickupDistance = 5.0f;
	public float throwForce = 200;

	bool shining = false;
	public GameObject prefab;

	GameObject player;
	GameObject inventory;

	bool hasPlayer = false;
	bool beingCarried = false;


	void Start() {
		player = GameObject.Find("Player");
		inventory = GameObject.Find("Inventory");
	}

	void Update() {
		float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
		if (dist <= pickupDistance) {
			hasPlayer = true;
			if (shining == false) {
				Instantiate (prefab, transform.position + new Vector3(0,0.5f,0), transform.rotation);
				shining = true;
			}
		}
		else {
			hasPlayer = false;
			shining = false;
		}
		if (hasPlayer && Input.GetMouseButtonDown(0)) {
			GetComponent<Rigidbody>().isKinematic = true;
			transform.position = inventory.transform.position;
			transform.parent = inventory.transform;
			beingCarried = true;
		}
		if (beingCarried) {
			if (Input.GetMouseButtonDown (2)) {
				GetComponent<Rigidbody> ().isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				GetComponent<Rigidbody> ().AddForce (inventory.transform.forward * throwForce);
			}
		} else {
			transform.LookAt(player.transform);
			//Vector3 rotation = transform.rotation.eulerAngles;
			//rotation.x = 0;
			//rotation.z = 0;
			//transform.rotation = Quaternion.Euler(rotation);
		}
	}
}

