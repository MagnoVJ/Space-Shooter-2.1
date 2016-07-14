using UnityEngine;
using System.Collections;
using System;

public class AimSimbolLocation : MonoBehaviour {

    [HideInInspector]
    public GameObject player = null;
    [HideInInspector]
    public GameObject inimigo = null;

    void Update() {

        if(player != null && inimigo != null)
            gameObject.transform.position = inimigo.transform.position + new Vector3(0.0f, 3.0f, 0.0f);
        else
            Destroy(gameObject);

    }

}
