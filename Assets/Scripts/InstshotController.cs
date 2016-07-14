using UnityEngine;
using System.Collections;

public class InstshotController : MonoBehaviour {
    
    public GameObject aimSimbol;

    private PerksController perksController;
    private Camera camera;

    void Start() {

        camera = Camera.main;

        perksController = gameObject.GetComponent<PerksController>();

    }

    void Update() {

        if (perksController.sightTimeActive && Input.GetMouseButtonDown(0)) {

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {


                Transform objectHit = hit.transform;

                if (objectHit.CompareTag("Enemy")) {

                    GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("AimSymbolTag");

                    foreach (GameObject gmObj in gameObjects)
                        Destroy(gmObj);

                    GameObject insAim = Instantiate(aimSimbol, objectHit.gameObject.transform.position, Quaternion.EulerAngles(0.0f, 0.0f, 0.0f)) as GameObject;

                    insAim.GetComponent<AimSimbolLocation>().player = gameObject;
                    insAim.GetComponent<AimSimbolLocation>().inimigo = objectHit.gameObject;

                }

            }

        }

    }

}