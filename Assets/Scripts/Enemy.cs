using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int health;
	private bool activate = false;
	private bool canAttack = true;
	public BoxCollider2D hitBox;
	public BoxCollider2D attackBox;
	public Transform target;//set target from inspector instead of looking in Update
    public float speed = 30f;
    public bool getActivate() {
		return activate;	
	}
	public void setActivate(bool con) {
		this.activate = con;
	}

	void Start()
    {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		if (hitBox == null) {
			hitBox = gameObject.AddComponent<BoxCollider2D> ();
		}
		if (attackBox == null) {
			attackBox = gameObject.AddComponent<BoxCollider2D> ();
			attackBox.isTrigger = true;
		}
    }

	void Update() {
		if (health == 0) {
			Destroy (gameObject);
			GameObject[] enemies = gameObject.GetComponentInParent<MapCollision>().enemies;
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
            if (Vector3.Distance(transform.position, target.position) > 1f) 
            {//move if distance from target is greater than 1
                transform.Translate(direction*speed*Time.deltaTime);
            }
        }
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.name == "character") {
			if (canAttack) {
				col.gameObject.GetComponent<Character> ().health -= 1;
				StartCoroutine (wait ());
			}
		}
	}

	IEnumerator wait() {
		canAttack = false;
		attackBox.enabled = false;
		yield return new WaitForSeconds (1);
		canAttack = true;
		attackBox.enabled = true;
	}
}