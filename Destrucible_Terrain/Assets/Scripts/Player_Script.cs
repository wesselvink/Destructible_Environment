using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb2D;
	private Vector2 moveVelocity;
	public GameObject projectile;

	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {
		if (Input.GetMouseButton (0)) {
			Instantiate (projectile, transform.position, Quaternion.identity);
		}	
		Vector2 moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		moveVelocity = moveInput.normalized * speed;
	}
	void FixedUpdate(){
		rb2D.MovePosition(rb2D.position + moveVelocity * Time.fixedDeltaTime);
	}
}
