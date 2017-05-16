using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour {

	public GameObject crop;

	void Start () {
	}

	void Update () {
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Plot") {
			transform.position = other.transform.position;
			Instantiate (crop, transform.position + new Vector3(0,0,0), transform.rotation);
			Destroy (gameObject);
		}
	}
}
