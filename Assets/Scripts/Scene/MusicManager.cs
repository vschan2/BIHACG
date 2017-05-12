using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	private GameObject musicManager;

	void Awake() {
		// Find MusicManager in the scene.
		musicManager = GameObject.Find ("BGMusic");

		// If there are no MusicManager in the scene.
		if (musicManager == null) {
			// Assign musicManager to currently attached script gameObject.
			musicManager = this.gameObject;

			// Rename the current gameObject to "MusicManager".
			musicManager.name = "BGMusic";

			// This object will not be destroyed, when travel to next scene.
			DontDestroyOnLoad (musicManager);

		} else {
			// Check the name of current gameObject.
			if (this.gameObject.name != "BGMusic") {
				// Destroy this gameObject.
				Destroy (this.gameObject);
			}
		}
	}
}
