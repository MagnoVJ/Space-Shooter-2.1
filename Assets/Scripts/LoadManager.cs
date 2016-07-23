using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadManager : MonoBehaviour {

    void Start() {

        if (Time.timeScale != 1)
            Time.timeScale = 1;

    }


    public void LoadSceneTelaInicial() {

        SceneManager.LoadScene("Level 0");

    }

    public void LoadSceneLevel1() {

        SceneManager.LoadScene("Level 1");

    }

    public void LoadSceneLevel0_1() {

        SceneManager.LoadScene("Level 0.1");

    }

   
}
