using UnityEngine;
using System.Collections;

public class MoveBolt : MonoBehaviour {

	public float speed;

	private Rigidbody rigidbody;

	void Start() {

		rigidbody = GetComponent<Rigidbody>();

		rigidbody.velocity = DirToMove(gameObject.transform.eulerAngles.y) * speed;

	}

	public Vector3 DirToMove(float angleInDegrees) {

		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

	}
	
}
