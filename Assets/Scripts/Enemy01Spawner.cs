using UnityEngine;
using System.Collections;

//My namespaces
using NSState;

public class Enemy01Spawner : MonoBehaviour {

	//if side == 0 choose side Up
	//if side == 1 choose side Right
	//if side == 2 choose side Left
	//if side == 3 choose side Bottom
	private int side;

	public GameObject enemy01;

	public Boundary spawnValuesUp;
	public Boundary spawnValuesLeft;
	public Boundary spawnValuesRight;
	public Boundary spawnValuesBottom;

	void Start() {

		side = Random.Range(0, 4);

	}

	void Update() {

		if (GameController.quantEnemy01emTela < 3) {
			SpawnEnemy();
			side = Random.Range(0, 4);
		}

	}

	void SpawnEnemy() {

		switch (side) {
			//Se side = 0 então será considerado o Up
			case 0: {

					Vector3 spawnPosition = new Vector3(Random.Range(spawnValuesUp.xMin, spawnValuesUp.xMax), 0.0f, spawnValuesUp.zMin);
					Quaternion spawnRotation;
					spawnRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
					Instantiate(enemy01, spawnPosition, spawnRotation);
					GameController.quantEnemy01emTela++;

					break;

				}
			//Se side = 1 então será considerado o Right
			case 1: {

					Vector3 spawnPosition = new Vector3(spawnValuesRight.xMin, 0.0f, Random.Range(spawnValuesRight.zMin, spawnValuesRight.zMax));
					Quaternion spawnRotation;
					spawnRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
					Instantiate(enemy01, spawnPosition, spawnRotation);
					GameController.quantEnemy01emTela++;

					break;

				}
			//Se side = 2 então será considerado o Left
			case 2: {

					Vector3 spawnPosition = new Vector3(spawnValuesLeft.xMin, 0.0f, Random.Range(spawnValuesLeft.zMin, spawnValuesLeft.zMax));
					Quaternion spawnRotation;
					spawnRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
					Instantiate(enemy01, spawnPosition, spawnRotation);
					GameController.quantEnemy01emTela++;

					break;

				}
			//Se side = 3 então será considerado o Bottom
			case 3: {

					Vector3 spawnPosition = new Vector3(Random.Range(spawnValuesBottom.xMin, spawnValuesBottom.xMax), 0.0f, spawnValuesBottom.zMin);
					Quaternion spawnRotation;
					spawnRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
					Instantiate(enemy01, spawnPosition, spawnRotation);
					GameController.quantEnemy01emTela++;

					break;

				}
		}

	}

}