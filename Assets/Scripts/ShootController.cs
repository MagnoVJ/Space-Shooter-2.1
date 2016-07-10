using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ShootController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private int pointerID;

	[HideInInspector]
	public bool pressed;

	void Awake() {

		pressed = false;

	}

	public void OnPointerDown(PointerEventData data) {

		if (!pressed) {
			pressed = true;
			pointerID = data.pointerId;
		}

	}

	public void OnPointerUp(PointerEventData data) {

		if (data.pointerId == pointerID)
			pressed = false;

	}

}