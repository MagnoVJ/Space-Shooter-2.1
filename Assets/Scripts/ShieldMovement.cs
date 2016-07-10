using UnityEngine;
using System.Collections;

public class ShieldMovement : MonoBehaviour {

	private Rigidbody rigidbody;

	public float speed;

	void Start() {

		rigidbody = GetComponent<Rigidbody>();

		rigidbody.velocity = speed * Vector3.forward;

	}

	void FixedUpdate() {

		gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 1.0f);
	
	}

	
}
