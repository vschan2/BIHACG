using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARScript : MonoBehaviour {

	public Transform CameraManager;
	public int managerID;
	public string team;
	public Transform Enemy;
	public bool isReady;

	public Transform ShootSpawnPos;
	public Rigidbody Projectile;
	public float Bullet_speed = 20;
	public float lifetime = 2.0f;

	public float playerHealth = 100f;
	public float maxPlayerHealth = 100f;
	public int PlayerDamage = 10;
	public int EnemyDamage = 10;
	public GameObject Healthbar;

	public AudioClip SfxEntrance;
	public AudioClip SfxAttack;
	public AudioClip SfxHurt;

	private Animation anim;
	private float attackDelay;
	private float animDelay;
	bool onceTrigger;
	float time;
	float hiddenCount;
	AudioSource audio;

	//Vector3 startPosition;
	//Vector3 oriPosition;
	//Transform oriParent;
	//private Quaternion oriRotate;

	void Awake() {
		audio = gameObject.AddComponent <AudioSource>() as AudioSource;
	}

	void Start () {
		anim = transform.GetComponent<Animation> ();
		//AudioSpawn = GameObject.Find("AudioSource").transform;
		attackDelay = 3;
		animDelay = 3;
		isReady = false;
		onceTrigger = false;
		//oriRotate = transform.rotation;
		//oriPosition = transform.localPosition;
		//oriParent = transform.parent;
		//ShowHealthbar = GameObject.Find("DisplayKamera");
		Healthbar.SetActive(false);
	}

	void Update () {
		isReady = transform.parent.GetComponent<DefaultTrackableEventHandler> ().mTrackedObjFound;

		if(isReady) {
			
			// If the character object is ready and haven't generated in the scene.
			if (onceTrigger == false) {	
				attackDelay = 3;

				//modelTrigger (true);

				//startPosition = transform.localPosition;
				//transform.localPosition += transform.up*0.9f;
				//Debug.Log(startPosition+" "+transform.localPosition);

				// onceTrigger change to true to allow rendered the character object's model in the scene once.
				onceTrigger = true;

				// Play the character entrance's sound.
				audio.clip = SfxEntrance;
				audio.Play ();
			}

			hiddenCount = 0;
			attackDelay -= Time.deltaTime;
			animDelay -= Time.deltaTime;
			//Debug.Log(attackDelay);
			//Debug.Log (Vector3.Distance (transform.position, Adudu.position));

			// The following statement is to assign the Enemy member variable (character object) to the second character object.
			if(CameraManager.GetComponent<CharacterManager> ().numOfCharacters > 1) {

				//Manager ID, need to update if we update the number of ID
				for(int i = 0; i < 2; i++) {

					if(CameraManager.GetComponent<CharacterManager> ().isReady [i] == true && i != managerID) {
						Enemy = CameraManager.GetComponent<CharacterManager> ().characters [i].transform.GetChild (0).transform;
					}
				}
				
			} else
				Enemy = null;

			// If the Enemy is in the scene.
			if (Enemy != null && Enemy.GetComponent<ARScript> ().isReady) {
				
				// If the team of Enemy is not the same team as this character object.
				if (team != Enemy.GetComponent<ARScript>().team) {
					transform.LookAt (Enemy.FindChild ("LookAtMe"), transform.parent.up);
					Healthbar.SetActive(true);

					// If the distance between this character object and Enemy is less than 300px,
					// initiate the battle.
					if (Vector3.Distance (transform.position, Enemy.position) < 300) {
						if (attackDelay <= 0) {
							anim.CrossFade ("attack");

							// Play the character attack's sound.
							audio.clip = SfxAttack;
							audio.Play ();

							//Debug.Log (this.name + " attacking");
							//Debug.Log ("Fire");

							//Rigidbody instantiatedProjectile = Instantiate ( projectile, transform.position,transform.rotation) as Rigidbody;
							//GameObject.Find ("Player").GetComponent<AudioSource>().PlayOneShot(GameObject.Find ("Player").GetComponent<Audio_Place>().player_attack);
							//instantiatedProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, Bullet_speed));
							//instantiatedProjectile.tag = gameObject.tag;
							//Destroy (instantiatedProjectile.gameObject, lifetime);

							// Shoot projectile.
							Invoke ("instantiatedProjectile", anim["attack"].length);

							// Play projectile sound.
							//GameObject sound = GameObject.Find ("AudioSource");
							//string a = gameObject.name;

							/*
							switch (a) {
								case ("Tanah"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().TanahFire);
									break;
								case ("Petir"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().PetirFire);
									break;
								case ("Adudu"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().AduduFire);
									break;
								case ("Angin"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().AnginFire);
									break;
								case ("Probe"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().ProbeFire);
									break;
								case ("Gempa"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().GempaFire);
									break;
								case ("Taufan"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().TaufanFire);
									break;
								case ("Ejojo"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().EjojoFire);
									break;
								case ("Fang"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().FangFire);
									break;
								case ("Halilintar"):
									sound.GetComponent<AudioSource> ().PlayOneShot (sound.GetComponent<AudioHolder> ().HalilintarFire);
									break;
							}
							*/

							attackDelay = 3;
							animDelay = 1;

						} else if (attackDelay > 0 && animDelay <= 0) {

							// If the battle end.
							anim.CrossFade ("stand");

							//Debug.Log (this.name + " standing 2");
						}
					}

				} else {

					// If the team of Enemy is the same team as this character object.
					anim.CrossFade ("run");
				}

			} else {

				// If there is no Enemy in the scene.

				if (attackDelay > 0) {
					anim.CrossFade ("block");
					//Debug.Log (this.name + " blocking 2");
					//transform.localPosition -= transform.parent.up* Time.deltaTime*0.3f;
					attackDelay -= Time.deltaTime ;

				} else {
					//transform.localPosition=oriPosition;
					anim.CrossFade ("stand");

					//Debug.Log (this.name + " standing 1");

					//transform.RotateAround(transform.parent.position, transform.up, 5);
				}

				//transform.rotation = oriRotate;
			}

		} else { 

			// If isReady is false.

			//transform.parent = null;
			hiddenCount += Time.deltaTime;			// Update hiddenCount value.

			// If hiddenCount is between 1 and 2, play the block animation.
			// Else remove this character object from the scene.
			if(hiddenCount > 1 && hiddenCount < 2) {
				//Debug.Log(anim.name);
				anim.CrossFade ("block");

				//Debug.Log (this.name + " blocking 1");


			} else if (hiddenCount > 2) {
				isReady = false;

				/*
				Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);

				foreach (Renderer component in rendererComponents) {
					component.enabled = false;
				}
				*/

				//transform.localPosition = oriPosition;
				onceTrigger = false;
				//transform.parent = oriParent;
			}

			Healthbar.SetActive (false);
		}
	}

	void instantiatedProjectile () {
		Rigidbody instantiatedProjectile = Instantiate (Projectile, ShootSpawnPos.position, ShootSpawnPos.rotation) as Rigidbody;
		//GameObject.Find ("Player").GetComponent<AudioSource>().PlayOneShot(GameObject.Find ("Player").GetComponent<Audio_Place>().enemy_attack);	
		instantiatedProjectile.velocity = transform.forward * Bullet_speed;		//transform.TransformDirection (new Vector3 (0, 0, Bullet_speed));
		instantiatedProjectile.tag = gameObject.tag;
		Destroy (instantiatedProjectile.gameObject, lifetime);
	}

	void modelTrigger (bool isModel) {
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);

		// Enable rendering:
		foreach (Renderer component in rendererComponents) {
			component.enabled = isModel;
		}

		// Enable colliders:
		foreach (Collider component in colliderComponents) {
			component.enabled = isModel;
		}
	}

	public void ReducePlayerHealth (float damage) {
		UnityEngine.UI.Image healthbar;

		playerHealth -= damage;

		// Play the character hurt's sound.
		audio.clip = SfxHurt;
		audio.Play ();

		healthbar = Healthbar.GetComponent<Transform> ().FindChild ("HealthBar_FrontBack").
					FindChild("HealthBar_Empty").FindChild("HealthBar_Fill").GetComponent<UnityEngine.UI.Image> ();
		healthbar.fillAmount = (float)playerHealth / (float)maxPlayerHealth;

		healthbar = Healthbar.GetComponent<Transform> ().FindChild ("HealthBar_LeftRight").
			FindChild("HealthBar_Empty").FindChild("HealthBar_Fill").GetComponent<UnityEngine.UI.Image> ();
		healthbar.fillAmount = (float)playerHealth / (float)maxPlayerHealth;
	}
}
