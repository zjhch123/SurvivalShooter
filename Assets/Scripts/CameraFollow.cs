using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5.0f;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}

	void FixedUpdate() {

		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (Camera.main.fieldOfView <= 50)
				Camera.main.fieldOfView += 2;
			if (Camera.main.orthographicSize <= 20)
				Camera.main.orthographicSize += 0.5F;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			if (Camera.main.fieldOfView > 2)
				Camera.main.fieldOfView -= 2;
			if (Camera.main.orthographicSize >= 1)
				Camera.main.orthographicSize -= 0.5F;

		}

		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}

}
