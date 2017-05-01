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
		Debug.Log ("On trigger enter");

		Other.gameObject.GetComponent<ARScript> ().ReducePlayerHealth (projectileDamage);

		//if (Other.gameObject.tag == "Ally" && gameObject.tag == "Enemy") {
		if (Other.gameObject.tag == "Ally") {
			Debug.Log ("Projectile hentam Ally");

			/*
			if (Other.gameObject.name == "Angin")
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().BBBHit);
			}
			else if (Other.gameObject.name == "Petir")
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().BBBHit);
			}
			else if (Other.gameObject.name == "Tanah")
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().BBBHit);
			}
			else if (Other.gameObject.name == "Taufan")
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().BBBHit);
			}
			else if (Other.gameObject.name == "Gempa")
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().BBBHit);
			}
			else if (Other.gameObject.name == "Halilintar")
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().BBBHit);
			}
			else if (Other.gameObject.name == "Fang")
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().FangHit);
			}
			else
			{
				Destroy (gameObject);	
			}
			*/

			Destroy (gameObject);

			//healthManager.ReducePlayerHealth();

		//} else if (Other.gameObject.tag == "Enemy" && gameObject.tag == "Ally") {
		} else if (Other.gameObject.tag == "Enemy") {
			//Debug.Log ("hentam " + Other.gameObject.name);
			Debug.Log ("Projectile hentam Enemy");

			/*
			if (Other.gameObject.name == "Probe")
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().ProbeHit);
			}
			else if (Other.gameObject.name == "Adudu") 
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().AduduHit);
			}
			else if (Other.gameObject.name == "Ejojo") 
			{
				AudioPlace.GetComponent<AudioSource>().PlayOneShot(AudioPlace.GetComponent<AudioHolder>().EjojoHit);
			}
			else
			{
				Destroy (gameObject);	
			}
			*/

			Destroy (gameObject);

			//healthManager.ReduceEnemyHealth();
		}
	}
}
