using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    Inventory inventory; 

	public int health;
    public int attackPower;
	private bool activate = false;
	private bool canAttack = true;
	public BoxCollider2D attackBox;
    public BoxCollider2D hitBox;
	public Transform target;
	public float speed = 30f;

	public bool getActivate () {
		return activate;
	}

	public void setActivate (bool con) {
		this.activate = con;
	}

	void Start ()
	{
		attackBox = gameObject.AddComponent<BoxCollider2D>();
        attackBox.isTrigger = true;
        hitBox = gameObject.AddComponent<BoxCollider2D>();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update ()
	{
		if (health <= 0) {
            inventory.addItemToInventory(1, 2);
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
				character.health -= attackPower;
				character.damagebreak = true; 
				StartCoroutine (wait ());
			}
		}
	}

	IEnumerator wait ()
	{
		canAttack = false;
		attackBox.enabled = false;
		yield return new WaitForSeconds (1);
		canAttack = true;
		attackBox.enabled = true;
	}
}
