using UnityEngine;
using System.Collections;

using NSState ;

public class PlayerController : MonoBehaviour {

	private AccelerateController accelerateController;
	private MoveLeftController moveLeftController;
	private MoveRightController moveRightController;
	private ShootController shootController;
	public GameObject shot;

	private float smoothedVelocityAccelerate = 0;
	private float smoothedDegreeMoveLeft = 0;
	[HideInInspector]
	private float smoothedDegreeMoveRight = 0;
	private float nextFire;
    private float nextFireForAim;

	public float speedAccelerate;
	public float smoothnessAccelerate;
	public float degreesRotateMoveLeft;
	public float smoothnessRotateMoveLeft;
	[HideInInspector]
	public float degreesRotateMoveRight;
	[HideInInspector]
	public float smoothnessRotateMoveRight;
	public float fireRate;

	public Boundary boundary;

    [HideInInspector]
    public GameObject enemyBeingTargeted;

	void Awake() {
		ParticleSystem.EmissionModule em = GameController.GetChildGameObject(gameObject, "engine_enemy").GetComponent<ParticleSystem>().emission; em.enabled = false;
		ParticleSystem.EmissionModule eml = GameController.GetChildGameObject(gameObject, "engine_left").GetComponent<ParticleSystem>().emission; eml.enabled = false;
		ParticleSystem.EmissionModule emr = GameController.GetChildGameObject(gameObject, "engine_Right").GetComponent<ParticleSystem>().emission; emr.enabled = false;
	}

	void Start() {

		degreesRotateMoveRight = degreesRotateMoveLeft;
		smoothnessRotateMoveRight = smoothnessRotateMoveLeft;
		degreesRotateMoveLeft *= -1;
		nextFire = 0.0f;
        nextFireForAim = 0.0f;

		accelerateController = GameObject.Find("Accelerate Button").GetComponent<AccelerateController>();
		moveLeftController = GameObject.Find("Move Left Button").GetComponent<MoveLeftController>();
		moveRightController = GameObject.Find("Move Right Button").GetComponent<MoveRightController>();
		shootController = GameObject.Find("Shoot Button").GetComponent<ShootController>();

        enemyBeingTargeted = null;

	}

	void Update() {

		//Verificacao caso o botao shot está sendo pressionado
        if (shootController.pressed && !ThereIsAimInScene() && ((Time.time - nextFireForAim) > 1)) {

			if (Time.time > nextFire && GameController.actualState == State.PLAYING && Time.timeScale == 1) {

				nextFire = Time.time + fireRate;

				GameObject shotSpawn = GameController.GetChildGameObject(gameObject, "Shot_Spawner");
				GameObject shotSpawn2 = GameController.GetChildGameObject(gameObject, "Shot_Spawner2");
				GameObject shotSpawn3 = GameController.GetChildGameObject(gameObject, "Shot_Spawner3");

				Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);

				if (gameObject.GetComponent<PerksController>().triShotTimeActive)
					InstantiatePlusTwoShot(shotSpawn2, shotSpawn3);

			}

		}
        else if (shootController.pressed && ThereIsAimInScene() && enemyBeingTargeted != null) {
            GameController.GetChildGameObject(enemyBeingTargeted, "Enemy_1_Correct_Rotation").GetComponent<DestroyByCollision>().DestroyInstantlyEnemy();
            nextFireForAim = Time.time;
            gameObject.GetComponent<PerksController>().quantSightShots -= 1;
        }
        

	}

	void FixedUpdate() {

		//Verificacao caso o botao acelerar esteja sendo pressionado
		if (accelerateController.pressed && GameController.actualState == State.PLAYING) {

			//Ativa o flare do ship engine
			ParticleSystem.EmissionModule em = GameController.GetChildGameObject(gameObject, "engine_enemy").GetComponent<ParticleSystem>().emission; em.enabled = true;

			smoothedVelocityAccelerate = Mathf.MoveTowards(smoothedVelocityAccelerate, speedAccelerate, smoothnessAccelerate);
			GetComponent<Rigidbody>().velocity = DirToMove(GetComponent<Rigidbody>().transform.eulerAngles.y) * smoothedVelocityAccelerate * (Time.deltaTime / Time.fixedDeltaTime);

			//Evita que o Player Ship saia dos valores mínimos e máximos estabelecidos
			GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

		} else if (accelerateController.pressed == false) { 
			//Ativa o flare do ship engine
			ParticleSystem.EmissionModule em = GameController.GetChildGameObject(gameObject, "engine_enemy").GetComponent<ParticleSystem>().emission; em.enabled = false;

			smoothedVelocityAccelerate = Mathf.MoveTowards(smoothedVelocityAccelerate, 0, smoothnessAccelerate * 1.5f);
			GetComponent<Rigidbody>().velocity = DirToMove(GetComponent<Rigidbody>().transform.eulerAngles.y) * smoothedVelocityAccelerate * (Time.deltaTime / Time.fixedDeltaTime);

			//Evita que o Player Ship saia dos valores mínimos e máximos estabelecidos
			GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

		}

		//Verificacao caso o botao mover esquerda esteja sendo pressionado
        if (moveLeftController.pressed && GameController.actualState == State.PLAYING) {

			//Ativa o flare do ship engine
			ParticleSystem.EmissionModule emr = GameController.GetChildGameObject(gameObject, "engine_Right").GetComponent<ParticleSystem>().emission; emr.enabled = true;

			smoothedDegreeMoveLeft = Mathf.MoveTowards(smoothedDegreeMoveLeft, degreesRotateMoveLeft, smoothnessRotateMoveLeft);
			GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), smoothedDegreeMoveLeft * (Time.deltaTime / Time.fixedDeltaTime));

			//Evita que o Player Ship saia dos valores mínimos e máximos estabelecidos
			GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

		} else if (moveLeftController.pressed == false) {

			//Ativa o flare do ship engine
			ParticleSystem.EmissionModule emr = GameController.GetChildGameObject(gameObject, "engine_Right").GetComponent<ParticleSystem>().emission; emr.enabled = false;

			smoothedDegreeMoveLeft = Mathf.MoveTowards(smoothedDegreeMoveLeft, 0, smoothnessRotateMoveLeft * 1.5f);
			GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), smoothedDegreeMoveLeft * (Time.deltaTime / Time.fixedDeltaTime));

		}

		//Verificacao caso o botao mover direita esteja sendo pressionado
        if (moveRightController.pressed && GameController.actualState == State.PLAYING) {

			//Ativa o flare do ship engine
			ParticleSystem.EmissionModule eml = GameController.GetChildGameObject(gameObject, "engine_left").GetComponent<ParticleSystem>().emission; eml.enabled = true;

			smoothedDegreeMoveRight = Mathf.MoveTowards(smoothedDegreeMoveRight, degreesRotateMoveRight, smoothnessRotateMoveRight);
			GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), smoothedDegreeMoveRight * (Time.deltaTime / Time.fixedDeltaTime));

			//Evita que o Player Ship saia dos valores mínimos e máximos estabelecidos
			GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

		} else if (moveRightController.pressed == false) {

			//Ativa o flare do ship engine
			ParticleSystem.EmissionModule eml = GameController.GetChildGameObject(gameObject, "engine_left").GetComponent<ParticleSystem>().emission; eml.enabled = false;

			smoothedDegreeMoveRight = Mathf.MoveTowards(smoothedDegreeMoveRight, 0, smoothnessRotateMoveRight * 1.5f);
			GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), smoothedDegreeMoveRight * (Time.deltaTime / Time.fixedDeltaTime));

		}

	}

	public Vector3 DirToMove(float angleInDegrees) {

		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

	}

	void InstantiatePlusTwoShot(GameObject shotSpawn2, GameObject shotSpawn3) {

		Instantiate(shot, shotSpawn2.transform.position, shotSpawn2.transform.rotation);
		Instantiate(shot, shotSpawn3.transform.position, shotSpawn3.transform.rotation);

	}

    private bool ThereIsAimInScene() {

        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("AimSymbolTag");

        if (gameobjects.Length > 0)
            return true;
        else
            return false;

    }

}