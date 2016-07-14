using UnityEngine;
using System.Collections;

public class HeartMovement : MonoBehaviour{

	private Rigidbody rigidbody;

	public float speed;

	void Start(){

		rigidbody = GetComponent<Rigidbody>();

		rigidbody.velocity = speed * Vector3.forward;

	}

	void FixedUpdate(){

		gameObject.transform.Rotate(new Vector3(0, 0, 1), 1.0f * (Time.deltaTime / Time.fixedDeltaTime));
	
	}

}
