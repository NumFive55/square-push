using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] enemies;
	public float thrust;
	public Text scoreText;
	public Text topScoreText;
	public Button restartButton;

	private float timer;
	private float topScore;
	private bool alive;
	private bool pause;

	void Start () {
		alive = true;
		pause = false;
		restartButton.gameObject.SetActive (false);
		StartCoroutine(Spawn ());	
		timer = 0;
		topScore = PlayerPrefs.GetFloat ("highscore", topScore);
		topScoreText.text = "TOP " + topScore.ToString("f0");
	}

	void Update () {
		if (alive == true) {
			timer += Time.deltaTime;
			scoreText.text = "" + timer.ToString ("f0");
		}

		if (alive == false) {
			// STOPS THE TIMER
			timer = timer;

			// SETS TOP SCORE VALUE IF THE TIMER IS GREATER THAN TOPSCORE VALUE
			if (timer > topScore) {
				topScore = timer;
				topScoreText.text = "TOP " + topScore.ToString("f0");
				PlayerPrefs.SetFloat ("highscore", topScore);
			}
		}
	}	

	public void Pause () {
		if (pause == false) {
			// freeze all enemy and player rigidbodies + timer
			StopCoroutine(Spawn ());
		} else if (pause == true) {
			
		}
	}

	public void GameOver () {		
		alive = false;
		restartButton.gameObject.SetActive (true);
	}

	public void Restart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
		
	IEnumerator Spawn () {

		while (true) {

			yield return new WaitForSeconds (Random.Range (0, 2));

//			Vector3 spawnPosition = new Vector3 (Random.Range (2f, -2f), 0.5f, 5f);
			Vector3 spawnPosition = new Vector3 (Random.Range (2f, -2f), 0.5f, 30f);
//			Vector3 spawnPosition = new Vector3 (Random.Range (2f, -2f), 0.5f, 75f);
			Instantiate (enemies [Random.Range (0, enemies.Length)], spawnPosition, Quaternion.identity);

			yield return new WaitForSeconds (Random.Range (0, 1));

		}
	}
}
