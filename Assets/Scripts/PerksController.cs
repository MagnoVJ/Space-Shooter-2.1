using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class PerksController : MonoBehaviour {

	enum Perks { TRISHOT, SHIELD, SIGHT };

	private GameObject sliderTriShot;
	private GameObject sliderShield;
	private GameObject sphereImmun;
    private GameObject sightShot;

    private const int QUANTSIGHTSHOTS = 3; //Quntidade de sight shots

	private List<Perks> perksVector;

	[HideInInspector]
	public bool triShotTimeActive;
	[HideInInspector]
	public bool shieldTimeActive;
    [HideInInspector]
    public bool sightTimeActive;

    public int quantSightShots;

	void Start() {

		sliderTriShot = GameController.sliderTriShotGC;
		sliderShield = GameController.sliderShieldGC;
		sphereImmun = GameController.sphereImmunGC;
        sightShot = GameController.sightShotGC;

		perksVector = new List<Perks>();

		triShotTimeActive = false;
		shieldTimeActive = false;
        sightTimeActive = false;

		sliderTriShot.GetComponent<Slider>().value = 0;
		sliderShield.GetComponent<Slider>().value = 0;

        sightShot.transform.FindChild("Quant Shots").gameObject.GetComponent<Text>().text = "";

		sliderTriShot.SetActive(false);
		sliderShield.SetActive(false);
        sightShot.SetActive(false);

	}

	void Update() {

		//TRI-SHOT
		if(sliderTriShot.GetComponent<Slider>().value > 0)
			sliderTriShot.GetComponent<Slider>().value -= Time.deltaTime;
		else
			sliderTriShot.GetComponent<Slider>().value = 0;

		if (sliderTriShot.GetComponent<Slider>().value == 0) { 


			if (sliderTriShot.active)
				sliderTriShot.SetActive(false);

			if (triShotTimeActive) {

				for (int i = 0; i < perksVector.Count; i++)
					if (perksVector[i] == Perks.TRISHOT)
						perksVector.RemoveAt(i);

			}

			triShotTimeActive = false;
		}

		//SHIELD
		if (sliderShield.GetComponent<Slider>().value > 0)
			sliderShield.GetComponent<Slider>().value -= Time.deltaTime;
		else
			sliderShield.GetComponent<Slider>().value = 0;

		if (sliderShield.GetComponent<Slider>().value == 0) {


			if (sliderShield.active)
				sliderShield.SetActive(false);

			if (shieldTimeActive) {

				for (int i = 0; i < perksVector.Count; i++)
					if (perksVector[i] == Perks.SHIELD)
						perksVector.RemoveAt(i);
			}


			shieldTimeActive = false;

		}

        //SIGHTSHOT
        sightShot.transform.FindChild("Quant Shots").gameObject.GetComponent<Text>().text = quantSightShots.ToString();

        if (quantSightShots == 0) {

            if (sightShot.active)
                sightShot.SetActive(false);

            if (sightTimeActive) {

                for (int i = 0; i < perksVector.Count; i++)
                    if (perksVector[i] == Perks.SIGHT)
                        perksVector.RemoveAt(i);

            }

            sightTimeActive = false;

        }


		if (perksVector.Count > 0) { 

			switch (perksVector[0]) {

			case Perks.TRISHOT:
				sliderTriShot.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -77.85999f);
				break;

			case Perks.SHIELD:
				sliderShield.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -77.85999f);
				break;

            case Perks.SIGHT:
                sightShot.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -77.85999f);
                break;

			}

		}

		if (perksVector.Count > 1) { 

			switch (perksVector[1]) {

			case Perks.TRISHOT:
				sliderTriShot.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -97.85995f);
				break;

			case Perks.SHIELD:
				sliderShield.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -97.85995f);
				break;

            case Perks.SIGHT:
                sightShot.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -97.85995f);
                break;

			}

		}

        if (perksVector.Count > 2) {

            switch (perksVector[2]) {

            case Perks.TRISHOT:
                sliderTriShot.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -117.86f);
                break;

            case Perks.SHIELD:
                sliderShield.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -117.86f);
                break;

            case Perks.SIGHT:
                sightShot.GetComponent<RectTransform>().anchoredPosition = new Vector2(-5.22998f, -117.86f);
                break;

            }

        }

		//Shield of immunity
		if (shieldTimeActive)
			sphereImmun.SetActive(true);
		else if (!shieldTimeActive)
			sphereImmun.SetActive(false);


	}

	public void ActivateTriShot() {

		if (triShotTimeActive == false)
			perksVector.Add(Perks.TRISHOT);

		sliderTriShot.SetActive(true);
		sliderTriShot.GetComponent<Slider>().value = sliderTriShot.GetComponent<Slider>().maxValue;
		triShotTimeActive = true;
				
	}

	public void ActivateShield() {

		if (shieldTimeActive == false)
			perksVector.Add(Perks.SHIELD);

		sliderShield.SetActive(true);
		sliderShield.GetComponent<Slider>().value = sliderShield.GetComponent<Slider>().maxValue;
		shieldTimeActive = true;
		
	}

    public void ActiveSight() {

        if (sightTimeActive == false)
            perksVector.Add(Perks.SIGHT);

        sightShot.SetActive(true);
        quantSightShots = QUANTSIGHTSHOTS;
        sightShot.transform.FindChild("Quant Shots").gameObject.GetComponent<Text>().text = quantSightShots.ToString();
        sightTimeActive = true;
        
    }
}
