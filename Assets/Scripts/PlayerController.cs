using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;

	public float thrust;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow)) {
			rb.AddForce (transform.forward * thrust);
		};

		if (Input.GetKey(KeyCode.RightArrow)) {			
			rb.AddForce (transform.right * thrust);
		} ;

		if (Input.GetKey(KeyCode.DownArrow)) {
			rb.AddForce (-transform.forward * thrust);
		} ;

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce (-transform.right * thrust);
		};

	}
}
