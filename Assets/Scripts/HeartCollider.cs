using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NSState;

public class HeartCollider : MonoBehaviour {

	private GameController gameController;
	private GameObject lifeBar;

	void Start(){

		gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
		lifeBar = GameObject.Find("LifeBar");

	} 

	void OnTriggerEnter(Collider other){

		if (GameController.actualState == State.PLAYING) {

			if (other.CompareTag("Player")) {

				if (gameController.GetLife() < gameController.maxLife) { 
					gameController.SetLife(gameController.GetLife() + 1);
					GameController.GetChildGameObject(lifeBar, "LifeTube").GetComponent<Slider>().value = gameController.GetLife();
				}

				gameController.AnimationScoreText(gameObject);

				Destroy(gameObject);
			
			}
		
		}
 	
	} 
	
}
