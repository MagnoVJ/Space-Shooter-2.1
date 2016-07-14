using UnityEngine;
using System.Collections;

public class AimAnimation : MonoBehaviour {

    private bool flag;
    private int quantEsc;

    private float dezPorCent;


    void Start() {

        flag = true;
        quantEsc = 0;

        dezPorCent = gameObject.transform.localScale.x * .01f;

    }

    void FixedUpdate() {

        if (quantEsc == 0 || quantEsc == 50) {
            flag = !flag;
            quantEsc = quantEsc == 50 ? --quantEsc : ++quantEsc;
        }

        if (flag == false) {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - dezPorCent, gameObject.transform.localScale.y - dezPorCent, gameObject.transform.localScale.z - dezPorCent) * (Time.deltaTime / Time.fixedDeltaTime);
            quantEsc++;
        }
        else {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + dezPorCent, gameObject.transform.localScale.y + dezPorCent, gameObject.transform.localScale.z + dezPorCent) * (Time.deltaTime / Time.fixedDeltaTime);
            quantEsc--;
        }
    }

}
