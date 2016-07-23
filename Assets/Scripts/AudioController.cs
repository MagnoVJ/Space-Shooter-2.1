using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioController : MonoBehaviour {

    private static AudioController instance = null;

    public static AudioController Instance {
        get { return instance;}
        set { instance = value; }
    }

    void Awake() {

        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else 
            instance = this;

        DontDestroyOnLoad(this.gameObject);

    }

    

}
