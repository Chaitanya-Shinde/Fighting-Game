using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform leftTarget;
	public Transform rightTarget;

	public float minDistance;

	// Update is called once per frame
	void Update () {
		float distanceBetweenTargets = Mathf.Abs (leftTarget.position.z - rightTarget.position.z) * 2;
		float centerPosition = (leftTarget.position.z + rightTarget.position.z)/ 2;

		transform.position = new Vector3 (
			// distanceBetweenTargets < minDistance? -distanceBetweenTargets: -minDistance ,
			// transform.position.y,
			// centerPosition
			centerPosition,
			transform.position.y,
			distanceBetweenTargets > minDistance? -distanceBetweenTargets: -minDistance
			);
	}
}
