using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Rigidbody rb;
	private float thrust;

	public float MinThrust;
	public float MaxThrust;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		thrust = Random.Range (MinThrust, MaxThrust); 
	}

	void Update () {
//		rb.velocity = -transform.forward * Random.Range(MinThrust, MaxThrust);
		rb.velocity = -transform.forward * thrust;
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Reached the end");
		enabled = false;
		rb.mass = 100;
	}
}
