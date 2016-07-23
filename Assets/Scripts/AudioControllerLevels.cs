using UnityEngine;
using System.Collections;

public class AudioControllerLevels : MonoBehaviour {

    void Awake() {

        if (AudioController.Instance != null) {
            Destroy(AudioController.Instance.gameObject);
            AudioController.Instance = null;
        }

    }

	
}
