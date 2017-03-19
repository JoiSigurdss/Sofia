using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSun : MonoBehaviour {

	GameObject target;

	void Start () {
		target = GameObject.Find("Sun");
	}

	void Update() {
		float step = 1000 * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
	}
}
