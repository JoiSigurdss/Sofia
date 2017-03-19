using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	void Update () {
		// Rotate the object around its local X axis at 1 degree per second
		transform.Rotate(Vector3.forward, Time.deltaTime/3);
	}
}
