using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float thrust;

	public float smoothing;

	private Vector2 origin;
	private Vector2 direction;
	private Vector2 actualDirection;
	private Vector2 smoothDirection;
	private bool touched;
	private int pointerID;

	public Vector2 startPos;
//	public Vector2 direction;

	private 

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {

		//COMPUTER CONTROLS

//		if (Input.GetKey(KeyCode.UpArrow)) {
//			rb.AddForce (transform.forward * thrust);
//		};
//
//		if (Input.GetKey(KeyCode.RightArrow)) {			
//			rb.AddForce (transform.right * thrust);
//		} ;
//
//		if (Input.GetKey(KeyCode.DownArrow)) {
//			rb.AddForce (-transform.forward * thrust);
//		} ;
//
//		if (Input.GetKey(KeyCode.LeftArrow)) {
//			rb.AddForce (-transform.right * thrust);
//		};

		Vector3 pos = transform.position;
		pos.z = Mathf.Clamp (pos.z, -8f, 1f);
		transform.position = pos;	

		smoothDirection = Vector2.MoveTowards (smoothDirection, direction, smoothing);
		Debug.Log("Smooth direction" + smoothDirection);
		Vector2 actualDirection = smoothDirection;
		Vector3 movement = new Vector3 (actualDirection.x, 0.0f, actualDirection.y);
//		rb.velocity = movement * thrust;
		Debug.Log("Movement" + movement);
		rb.AddForce (movement * thrust);

		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			// Handle finger movements based on TouchPhase
			switch (touch.phase)
			{
			//When a touch has first been detected, change the message and record the starting position
			case TouchPhase.Began:
				// Record initial touch position.
				startPos = touch.position;
				Debug.Log ("Start Pos" + startPos);
				break;

				//Determine if the touch is a moving touch
			case TouchPhase.Moved:
				// Determine direction by comparing the current touch position with the initial one
				Vector2 directionRaw = touch.position - startPos;
				direction = directionRaw.normalized;
				Debug.Log("Direction Norm" + direction);
				break;

			case TouchPhase.Ended:
				// Report that the touch has ended when it ends

				break;
			}
		}

	}
		
//	public Vector2 GetDirection () {
//		smoothDirection = Vector2.MoveTowards (smoothDirection, direction, smoothing);
//		return smoothDirection;
//		Debug.Log("Smooth direction" + smoothDirection);
//	}
}
