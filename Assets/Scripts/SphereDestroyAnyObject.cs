using UnityEngine;
using System.Collections;

public class SphereDestroyAnyObject : MonoBehaviour {

	private GameController gameController; 

	public GameObject explosionEnemy1;


	void Start() {

		gameController = GameObject.Find("Game Controller").GetComponent<GameController>();

	}

	void OnTriggerEnter(Collider other) {

		if (other.CompareTag("BoltEnemy")) {

			gameController.UpdateScorePlayer(other.gameObject);
			gameController.AnimationScoreText(other.gameObject);
			
			Destroy(other.gameObject);

		}

		if (other.CompareTag("Enemy")) {

			gameController.UpdateScorePlayer(other.gameObject);
			gameController.AnimationScoreText(other.gameObject);

			Instantiate(explosionEnemy1, other.GetComponent<Transform>().position, other.GetComponent<Transform>().rotation);
			Destroy(other.gameObject.transform.parent.gameObject);

		}

	}

}
