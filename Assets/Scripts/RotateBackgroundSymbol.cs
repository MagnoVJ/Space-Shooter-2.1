using UnityEngine;
using System.Collections;

public class RotateBackgroundSymbol : MonoBehaviour {

    public float speedRotation;

    void FixedUpdate() {

        gameObject.transform.Rotate(Vector3.up * speedRotation * Time.deltaTime, Space.World);

        

    }

	
}
