using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int health;
	private bool activate = false;

	public bool getActivate() {
		return activate;	
	}
	public void setActivate(bool con) {
		this.activate = con;
	}


	void Start()
    {
    
    }

	void Update() {
		if (this.health == 0) {
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
		if (this.activate) {
			// add movement here

		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		while (col.gameObject.name == "character") {
			col.gameObject.GetComponent<Character> ().health -= 1;
			StartCoroutine (wait ());
			Debug.Log ("Pow!");

		}
	}

	IEnumerator wait() {
		yield return new WaitForSecondsRealtime (1f);
	}
}