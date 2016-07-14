using UnityEngine;
using System.Collections;
using NSState;

public class SightSpawner : MonoBehaviour {

    public GameObject[] sightSimbolVector;
    public Vector3 spawnValues;
    public float startWait;
    public float spawnWait;
    public float constWait;

    void Start() {

        StartCoroutine("SpawnWaves");

    }

    void Update() {

        if ((GameController.actualState == State.GAMEOVER) || (GameController.actualState == State.PROXIMONIVEL))
            StopCoroutine("SpawnWaves");

    }

    IEnumerator SpawnWaves() {

        yield return new WaitForSeconds(constWait);

        yield return new WaitForSeconds(Random.Range(0, startWait));

        while (true) {

            GameObject sightSimbol = sightSimbolVector[Random.Range(0, sightSimbolVector.Length)];

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

            Instantiate(sightSimbol, spawnPosition, Quaternion.Euler(0.0f, 0.0f, 0.0f));

            yield return new WaitForSeconds(constWait);

            yield return new WaitForSeconds(Random.Range(0, spawnWait));

        }

    }

}
