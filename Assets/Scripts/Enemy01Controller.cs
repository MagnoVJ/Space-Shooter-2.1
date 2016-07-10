using UnityEngine;
using System.Collections;
using NSState;

public class Enemy01Controller : MonoBehaviour {

	enum StateEnemy {LOOKINGFORPOSITION, MOVINGTOPOSITION, LOOKINGFORPLAYER};

	private GameObject boxEnemyPositioning;
	private Rigidbody rigidbody;
	private Vector3 destino;
	private Quaternion lookRotation;
	private Vector3 direction;
	private StateEnemy currentState;
	private FieldOfView fieldOfView;
	private float nextFire;
	private float timeChangeState;

	public float speed;
	public float smoothnessRotateMove;
	public float fireRate;
	public GameObject shot;

	void Start() {

		boxEnemyPositioning = GameObject.Find("Box Enemy Positioning");
		rigidbody = GetComponent<Rigidbody>();
		fieldOfView = GetComponent<FieldOfView>();
		nextFire = 0.0f;

		GameController.quantEnemy01emTela = GameController.quantEnemy01emTela++;

		destino = GenerateDestiny();
		currentState = StateEnemy.LOOKINGFORPOSITION;

		ParticleSystem.EmissionModule em = GameController.GetChildGameObject(gameObject, "Engine_Flare_Enemy_1").GetComponent<ParticleSystem>().emission; em.enabled = false;

	}

	void Update() {

		switch (currentState) {

			//case StateEnemy.MOVINGTOPOSITION:
			case StateEnemy.LOOKINGFORPOSITION: 
			case StateEnemy.LOOKINGFORPLAYER: {

					if (fieldOfView.seeingPlayer && verifyIfEnemyInsideBox()) {

						if (Time.time > nextFire && GameController.actualState == State.PLAYING && Time.timeScale == 1) {
							nextFire = Time.time + fireRate;
							GameObject shotSpawn = GameController.GetChildGameObject(gameObject, "Shot_Spawner");
							Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
						}

					}

					break;

				}
		}

	}

	void FixedUpdate() {

		switch (currentState) {

			case StateEnemy.LOOKINGFORPOSITION: {

					if (GameController.actualState == State.PLAYING) { 

						//find the vector pointing from our position to the target
						direction = (destino - rigidbody.transform.position).normalized;
						//create the rotation we need to be in to look at the target
						lookRotation = Quaternion.LookRotation(direction);
						rigidbody.transform.rotation = Quaternion.RotateTowards(rigidbody.transform.rotation, lookRotation, smoothnessRotateMove * (Time.deltaTime / Time.fixedDeltaTime));

						if ((int)rigidbody.transform.eulerAngles.y == (int)lookRotation.eulerAngles.y) { 
							currentState = StateEnemy.MOVINGTOPOSITION;
							ParticleSystem.EmissionModule em = GameController.GetChildGameObject(gameObject, "Engine_Flare_Enemy_1").GetComponent<ParticleSystem>().emission; em.enabled = true;
						}

					}

					break;
				}

			case StateEnemy.MOVINGTOPOSITION: {

					if (GameController.actualState == State.PLAYING) { 

						rigidbody.velocity = direction * speed * (Time.deltaTime / Time.fixedDeltaTime);

						if ((int)rigidbody.transform.position.x == (int)destino.x &&
							(int)rigidbody.transform.position.y == (int)destino.y &&
							(int)rigidbody.transform.position.z == (int)destino.z) {

							rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
							currentState = StateEnemy.LOOKINGFORPLAYER;
							timeChangeState = Time.time;
							ParticleSystem.EmissionModule em = GameController.GetChildGameObject(gameObject, "Engine_Flare_Enemy_1").GetComponent<ParticleSystem>().emission; em.enabled = false;

						}

					}

					break;

				}

			case StateEnemy.LOOKINGFORPLAYER: {

					if (GameController.actualState == State.PLAYING) { 

						//find the vector pointing from our position to the target
						try {
							direction = (GameObject.FindGameObjectWithTag("Player").transform.position - rigidbody.transform.position).normalized;
						} catch (System.Exception err) {
							Debug.Log("Exception catched: " + err);
							break;
						}
						//create the rotation we need to be in to look at the target
						lookRotation = Quaternion.LookRotation(direction);
						rigidbody.transform.rotation = Quaternion.RotateTowards(rigidbody.transform.rotation, lookRotation, smoothnessRotateMove * (Time.deltaTime / Time.fixedDeltaTime));

						if (Time.time - timeChangeState > 10.0f) {
							destino = GenerateDestiny();
							currentState = StateEnemy.LOOKINGFORPOSITION;
						}

					}
						
					break;

				}

		}

	}

	private Vector3 GenerateDestiny() {

		float destX = Random.Range(boxEnemyPositioning.GetComponent<Renderer>().bounds.min.x, boxEnemyPositioning.GetComponent<Renderer>().bounds.max.x);
		float destY = 0.0f;
		float destZ = Random.Range(boxEnemyPositioning.GetComponent<Renderer>().bounds.min.z, boxEnemyPositioning.GetComponent<Renderer>().bounds.max.z);

		return new Vector3(destX, destY, destZ);

	}

	private bool verifyIfEnemyInsideBox() {

		if ((gameObject.transform.position.x > boxEnemyPositioning.GetComponent<Renderer>().bounds.min.x) &&
			(gameObject.transform.position.x < boxEnemyPositioning.GetComponent<Renderer>().bounds.max.x) &&
			(gameObject.transform.position.z > boxEnemyPositioning.GetComponent<Renderer>().bounds.min.z) &&
			(gameObject.transform.position.z < boxEnemyPositioning.GetComponent<Renderer>().bounds.max.z))
			return true;
		else
			return false;
	}

	void OnDestroy() {

		GameController.quantEnemy01emTela = --GameController.quantEnemy01emTela;

	}

}