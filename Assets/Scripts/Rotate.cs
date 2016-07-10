using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float amountToRotate;

	void FixedUpdate() {

		gameObject.transform.Rotate(new Vector3(0, 1, 0) * (amountToRotate * (Time.deltaTime / Time.fixedDeltaTime)));

	}
	
}
