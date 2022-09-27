using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject Player;
	public Rigidbody rb;
	public float speed = 3f;
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
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(movement*speed);



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
