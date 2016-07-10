using UnityEngine;
using System.Collections;

public class SpherePosition : MonoBehaviour {


	void FixedUpdate() {

		gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

	}
}
