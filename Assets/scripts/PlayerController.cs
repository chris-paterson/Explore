using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpHeight;

	private Rigidbody rb;
	private bool isFalling;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void FixedUpdate ()
	{
		float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		float strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		Vector3 movement = new Vector3 (strafe, 0.0f, translation);

		if (Input.GetKeyDown ("space") && !isFalling) {
			rb.velocity = new Vector3 (0.0f, jumpHeight, 0.0f);
			isFalling = true;
		}

		
		transform.Translate (movement);

		if (Input.GetKeyDown("escape")) 
			Cursor.lockState = CursorLockMode.None;
	}

	void OnCollisionStay() {
		isFalling = false;
	}
}