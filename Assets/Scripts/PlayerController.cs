using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject Player;
	public Rigidbody rb;
	public float speed;
	public float rotSpeed;
	public float jumpForce = 50f;
	public LayerMask groundLayers;
	public CapsuleCollider col;
	public bool grounded;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();
	}

	void Update () 
	{
		// Gets Player Input
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		// Gets Camera directions
		Vector3 forward = Camera.main.transform.forward;
		Vector3 right = Camera.main.transform.right;
		forward.y = 0;
		right.y = 0;
		forward = forward.normalized;
		right = right.normalized;

		// These vectors multiply to make camera-relative vectors
		Vector3 forwardRelativeInput = moveVertical * forward;
		Vector3 rightRelativeInput = moveHorizontal * right;

		Vector3 movement = forwardRelativeInput + rightRelativeInput;

		transform.Translate(movement * speed * Time.deltaTime, Space.World);
		// rb.AddForce(movement * speed);

		if (movement != Vector3.zero)
		{
			Quaternion faceRotation = Quaternion.LookRotation(movement, Vector3.up);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, faceRotation, rotSpeed * Time.deltaTime);
		}


		if (IsGrounded())
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
			}
			
		}
		else
		{
			rb.AddForce((Vector3.down*jumpForce)*Time.deltaTime, ForceMode.Impulse);
		}
		
		if (Player.transform.position.y < -15)
		{
			Player.transform.position = new Vector3(0, 1.25f, 0);		
		}
	}
	public bool IsGrounded()
	{
		grounded = Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius, groundLayers);
		return grounded;
	}
	void OnTriggerEnter(Collider other)
	{
		
	}
}
