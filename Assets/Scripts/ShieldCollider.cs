using UnityEngine;
using System.Collections;
using NSState;

public class ShieldCollider : MonoBehaviour {

	private GameController gameController;

	void Start() {

		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

	}

	void OnTriggerEnter(Collider other) {

		if (GameController.actualState == State.PLAYING && other.CompareTag("Player")) {

			other.transform.parent.gameObject.GetComponent<PerksController>().ActivateShield();

			gameController.AnimationScoreText(gameObject);

			Destroy(gameObject);

		}

	}
	
}
