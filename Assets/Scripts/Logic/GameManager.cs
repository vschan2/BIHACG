using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GameManager : MonoBehaviour {

	public GameObject[] characters;
	public bool[] isReady;
	public int numOfActivities;

	private int indexCharactersWin;
	private bool isGameOver;

	GameObject startLogo;
	GameObject UICanvas;

	void Start () {
		startLogo = GameObject.Find ("StartLogo");

		UICanvas = GameObject.Find ("UICanvas");
		UICanvas.SetActive (false);

		numOfActivities = 0;
		isGameOver = false;
	}

	void Update () {
		int count = 0;

		// To detect the character's card in the scene.
		for (int i = 0; i < characters.Length; i++) {
			//if (characters [i].activeSelf) {
			if (characters [i].GetComponent<DefaultTrackableEventHandler> ().mTrackedObjFound) {
				numOfActivities++;
				isReady [i] = true;
				count++;

			} else
				isReady [i] = false;
				
		}

		if (count <= 0) {
			numOfActivities = 0;
			startLogo.SetActive (true);
			// TODO: StartLogo fading in.

		} else {
			startLogo.SetActive (false);
			
		}

		// Restart game if game is over.
		if (isGameOver && numOfActivities == 0) {
			Debug.Log ("Reload level! ");
			Application.LoadLevel ("test2");
			// TODO: StartLogo fading out.

		}
	}

	public void setIndexCharactersWin(int icw) {
		indexCharactersWin = icw;
	}

	public void GameOver() {
		isGameOver = true;

		// When game is over, the characters (except win character) cannot be shown in the scene.
		for (int i = 0; i < characters.Length; i++) {
			if (i != indexCharactersWin) {
				characters [i].GetComponent<ImageTargetBehaviour> ().enabled = false;

			}
		}

		// Displays the game over UIs.
		Canvas[] canvas = UICanvas.GetComponentsInChildren<Canvas>();

		for (int i = 0; i < canvas.Length; i++) {
			string winnerName = characters [indexCharactersWin].GetComponentInChildren<ARScript> ().name;

			canvas[i].transform.FindChild("Panel").FindChild("WinnerText").GetComponent<Text>().text = winnerName + " Win!!!";
			//canvas [i].GetComponentInChildren<Text> ().text = winnerName + " Win!!!";
		}

		UICanvas.SetActive (true);
	}
}
