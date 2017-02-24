using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5f;

	Vector3 movement;
	Animator anim; // Animation Controller
	Rigidbody playRigidbody;
	int floorMask;
	float camRayLength = 100f;


	void Awake() { // Init
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator> ();
		playRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		// Get X and Z
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Move (h, v); // Controller move
		Turning (); // Controller Turn
		Animating (h, v); // Controller Animator

	}

	void Move(float h, float v) {
		movement.Set (h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playRigidbody.MovePosition (transform.position + movement);
	}

	void Turning() {
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newAngler = Quaternion.LookRotation (playerToMouse);
			playRigidbody.MoveRotation (newAngler);
		
		}
	}

	void Animating(float h, float v) {
		bool isWalking = (h != 0f || v != 0f);
		anim.SetBool ("IsWalking", isWalking);

	}

}
