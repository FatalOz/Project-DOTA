using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	
	public int health;
	private bool activate = false;
	private bool canAttack = true;
	public Transform target;
//set target from inspector instead of looking in Update
	public float speed = 30f;

	public bool getActivate ()
	{
		return activate;	
	}

	public void setActivate (bool con)
	{
		this.activate = con;
	}


	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update ()
	{
		if (health == 0) {
			Destroy (gameObject);
			GameObject[] enemies = gameObject.GetComponentInParent<MapCollision> ().enemies;
			int index = 0;
			foreach (GameObject enemy in enemies) {
				if (enemy == gameObject) {
					enemies [index] = null;
					break;
				} else {
					index++;
				}
			}
		}
		if (activate && canAttack) {
			Vector3 direction = target.position - transform.position;
			direction = direction.normalized;
			//move towards the player
			if (Vector3.Distance (transform.position, target.position) > 1f) {//move if distance from target is greater than 1
				transform.Translate (direction * speed * Time.deltaTime);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name == "character") {
			Character character = col.gameObject.GetComponent<Character>();
			if (canAttack) {
				character.health -= 1;
				character.damagebreak = true;
				Debug.Log ("Pow!");
				StartCoroutine (wait ());
			} 
		} 
	}

	IEnumerator wait ()
	{
		canAttack = false;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		yield return new WaitForSeconds (1);
		canAttack = true;
		gameObject.GetComponent<BoxCollider2D> ().enabled = true;
	}
}