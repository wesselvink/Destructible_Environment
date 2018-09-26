using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private Vector2 target;
	public float speed;
	public int damage;

	public float aereaOfEffect;
	public LayerMask whatIsDestructible;



	void Start () {
		target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
		if (Vector2.Distance (transform.position, target) < 0.1f) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Environment")){
			Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, aereaOfEffect, whatIsDestructible);
			for(int i = 0; i < objectsToDamage.Length; i++){
				objectsToDamage [i].GetComponent<Environment> ().health -= damage;
			}
		}
	}
		
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, aereaOfEffect);
	}

}
