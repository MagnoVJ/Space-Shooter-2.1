using UnityEngine;
using System.Collections;

public class AudioVerificationExplosion : MonoBehaviour {

    void Awake() {

        if (!ActDesactSoundController.AudioActivate) {
            gameObject.GetComponent<AudioSource>().mute = true;
            
        }


    }
}
