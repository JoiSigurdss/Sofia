using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSun : MonoBehaviour {

	GameObject target;

	void Start () {
		target = GameObject.Find("Sun");
	}

	void Update() {
		transform.LookAt(target.transform);
		Vector3 rotation = transform.rotation.eulerAngles;
		rotation.x = 0;
		rotation.z = 0;
		transform.rotation = Quaternion.Euler(rotation);
	}
}
