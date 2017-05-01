using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CharacterManager : MonoBehaviour {

	public GameObject[] characters;
	public bool[] isReady;
	public int numOfCharacters;

	void Start () {
		numOfCharacters = 0;
	}

	void Update () {
		int count = 0;

		for (int i = 0; i < characters.Length; i++) {
			//if (characters [i].activeSelf) {
			if (characters [i].GetComponent<DefaultTrackableEventHandler>().mTrackedObjFound) {
				numOfCharacters++;
				isReady [i] = true;
				count++;

			} else
				isReady [i] = false;
		}

		if (count <= 0) {
			numOfCharacters = 0;
		}
	}
}
