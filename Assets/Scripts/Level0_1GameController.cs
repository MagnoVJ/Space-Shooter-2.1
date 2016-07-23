using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Level0_1GameController : MonoBehaviour {

    void Start() {

        FileDealer fileDealer = new FileDealer();

        GameObject pontuacao1, pontuacao2, pontuacao3, pontuacao4, pontuacao5;
        GameObject simb1, simb2, simb3, simb4, simb5;
        GameObject score1, score2, score3, score4, score5;

        simb1 = GameObject.Find("Pt Simb 1");
        simb2 = GameObject.Find("Pt Simb 2");
        simb3 = GameObject.Find("Pt Simb 3");
        simb4 = GameObject.Find("Pt Simb 4");
        simb5 = GameObject.Find("Pt Simb 5");

        pontuacao1 = GameObject.Find("Pontuacao 1");
        pontuacao2 = GameObject.Find("Pontuacao 2");
        pontuacao3 = GameObject.Find("Pontuacao 3");
        pontuacao4 = GameObject.Find("Pontuacao 4");
        pontuacao5 = GameObject.Find("Pontuacao 5");

        score1 = GameObject.Find("Score 1");
        score2 = GameObject.Find("Score 2");
        score3 = GameObject.Find("Score 3");
        score4 = GameObject.Find("Score 4");
        score5 = GameObject.Find("Score 5");

        simb1.SetActive(false);
        simb2.SetActive(false);
        simb3.SetActive(false);
        simb4.SetActive(false);
        simb5.SetActive(false);

        pontuacao1.SetActive(false);
        pontuacao2.SetActive(false);
        pontuacao3.SetActive(false);
        pontuacao4.SetActive(false);
        pontuacao5.SetActive(false);

        score1.SetActive(false);
        score2.SetActive(false);
        score3.SetActive(false);
        score4.SetActive(false);
        score5.SetActive(false);

        if (fileDealer.Load() != null) {

            List<int> scoreVector = fileDealer.Load();

            if(scoreVector.Count >= 1){
                simb1.SetActive(true);
                pontuacao1.SetActive(true);
                score1.SetActive(true);
                score1.GetComponent<Text>().text = scoreVector[0].ToString();
            }

            if (scoreVector.Count >= 2) {
                simb2.SetActive(true);
                pontuacao2.SetActive(true);
                score2.SetActive(true);
                score2.GetComponent<Text>().text = scoreVector[1].ToString();
            }

            if (scoreVector.Count >= 3) {
                simb3.SetActive(true);
                pontuacao3.SetActive(true);
                score3.SetActive(true);
                score3.GetComponent<Text>().text = scoreVector[2].ToString();
            }

            if (scoreVector.Count >= 4) {
                simb4.SetActive(true);
                pontuacao4.SetActive(true);
                score4.SetActive(true);
                score4.GetComponent<Text>().text = scoreVector[3].ToString();
            }

            if (scoreVector.Count >= 5) {
                simb5.SetActive(true);
                pontuacao5.SetActive(true);
                score5.SetActive(true);
                score5.GetComponent<Text>().text = scoreVector[4].ToString();
            }

            GameObject.Find("Descricao 2").GetComponent<Text>().text = "Consiga uma pontuação maior do que a última pontuação listada acima. A sua menor pontuação atualmente é: " + scoreVector[scoreVector.Count - 1] + ". Consiga uma pontuação maior do que " + scoreVector[scoreVector.Count - 1] + " para ela aparecer na lista.";

        }
        else
            GameObject.Find("Descricao 2").GetComponent<Text>().text = "Consiga uma pontuação maior do que a última pontuação listada acima. A sua menor pontuação atualmente é: 0. Consiga uma pontuação maior do que 0 para ela aparecer na lista.";

    }
	
}