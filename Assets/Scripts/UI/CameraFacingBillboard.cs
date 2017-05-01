using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour {

	public Camera targetCamera;

	void Update () {
		transform.LookAt(transform.position + targetCamera.transform.rotation * Vector3.forward,
			targetCamera.transform.rotation * Vector3.up);
	}
}
