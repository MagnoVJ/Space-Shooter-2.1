using UnityEngine;
using System.Collections;

public class DestroyObjects : MonoBehaviour{

	void OnTriggerExit(Collider other){

		if (other.CompareTag("Enemy"))
			Destroy(other.gameObject.transform.parent.gameObject);
		else
			Destroy(other.gameObject);
	}

}
