using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollide : MonoBehaviour {

	public float projectileDamage;
	public Transform AudioPlace;
	public HealthManager healthManager;


	// Use this for initialization
	void Start () {
		//AudioPlace = GameObject.Find("AudioSource").transform;
		//healthManager = GameObject.Find ("DisplayKamera").GetComponent<HealthManager>();
	}

	void OnTriggerEnter (Collider Other) {
		//Debug.Log ("On trigger enter");

		Other.gameObject.GetComponent<ARScript> ().ReducePlayerHealth (projectileDamage);
		Destroy (gameObject);
	}
}
