using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

	GameObject target;

	void Start () {
		target = GameObject.Find("Player");
	}

	void Update() {
		float step = 1000 * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
	}
}
