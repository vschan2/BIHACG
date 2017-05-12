using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour {

	[Header("Settings")]
	public float Speed = 1.0f;

	void Update () {
		this.transform.Rotate(transform.position.x, Speed, transform.position.z);
	}
}
