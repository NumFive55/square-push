using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

	GameController gameController;

	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter (Collider other) {
		Destroy (other.gameObject);

		if (other.tag == "Player") {			
			gameController.GameOver ();
		}
	}

}
