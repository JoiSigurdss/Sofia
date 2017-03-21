using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

	GameObject target;

	public bool lockAxis = true;

	void Start () {
		target = GameObject.Find("FPSCamera");
	}

	void Update() {
		transform.LookAt (target.transform);
		if (lockAxis == true) {
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation.x = 0;
			rotation.z = 0;
			transform.rotation = Quaternion.Euler (rotation);
		}
	}
}	
