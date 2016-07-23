using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActDesactSoundController : MonoBehaviour {

    public Sprite loudSpriteSymbol;
    public Sprite muteSpriteSymbol;

    private static bool audioActivate = true;

    public static bool AudioActivate {
        get { return audioActivate; }
        set { audioActivate = value; }
    }

    void Start(){

        if (ActDesactSoundController.AudioActivate) {
            gameObject.GetComponent<Image>().sprite = loudSpriteSymbol;
            GameObject.Find("Audio Controller").GetComponent<AudioSource>().mute = false;
        }
        else {
            gameObject.GetComponent<Image>().sprite = muteSpriteSymbol;
            GameObject.Find("Audio Controller").GetComponent<AudioSource>().mute = true;
        }
    
    }

    public void ActivateDesactivateAudio() {

        ActDesactSoundController.AudioActivate = !ActDesactSoundController.AudioActivate;

        if (ActDesactSoundController.AudioActivate) {
            gameObject.GetComponent<Image>().sprite = loudSpriteSymbol;
            GameObject.Find("Audio Controller").GetComponent<AudioSource>().mute = false;
        }
        else {
            gameObject.GetComponent<Image>().sprite = muteSpriteSymbol;
            GameObject.Find("Audio Controller").GetComponent<AudioSource>().mute = true;
        }

    }
	
}
