using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {

	public float viewRadius;
	[Range(0, 360)]
	public float viewAngle;
	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();
	public float meshResolution;

	[HideInInspector]
	public bool seeingPlayer;

	void Start() {

		StartCoroutine("FindTargetWithDelay", .2f);

	}

	void Update() {

		DrawFieldOfView();

		if (visibleTargets.Count > 0)
			seeingPlayer = true;
		else
			seeingPlayer = false;

	}

	IEnumerator FindTargetWithDelay(float delay) {

		while (true) {
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}

	}

	void FindVisibleTargets() {

		visibleTargets.Clear();

		Collider[] targetsInViewRadius = Physics.OverlapSphere(gameObject.transform.position, viewRadius);

		for (int i = 0; i < targetsInViewRadius.Length; i++) {

			if (targetsInViewRadius[i].CompareTag("Player")) {

				Transform playerTarget = targetsInViewRadius[i].transform;
				Vector3 dirToTarget = (playerTarget.position - gameObject.transform.position).normalized;

				if (Vector3.Angle(gameObject.transform.forward, dirToTarget) < viewAngle / 2) {

					float dstToTarget = Vector3.Distance(gameObject.transform.position, playerTarget.position);
					visibleTargets.Add(playerTarget);

				}

			}

		}

	}

	void DrawFieldOfView() {

		int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
		float stepAngleSize = viewAngle / stepCount;

		for (int i = 0; i <= stepCount; i++) {  
			float angle = gameObject.transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
			Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + DirFromAngle(angle, true) * viewRadius, Color.red);
		}
	}

	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {

		if (!angleIsGlobal)
			angleInDegrees += gameObject.transform.eulerAngles.y;

		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0.0f, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}
}
