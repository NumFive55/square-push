using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] enemies;
	public float thrust;

	void Start () {
		StartCoroutine(Spawn ());	
	}


	IEnumerator Spawn () {

		while (true) {

//			yield return new WaitForSeconds (Random.Range (0, 2));

			Vector3 spawnPosition = new Vector3 (Random.Range (2f, -2f), 0.5f, 5f);
//			Vector3 spawnPosition = new Vector3 (Random.Range (2f, -2f), 0.5f, 75f);
			Instantiate (enemies [Random.Range (0, enemies.Length)], spawnPosition, Quaternion.identity);

			yield return new WaitForSeconds (Random.Range (0, 2));

		}
	}
}
