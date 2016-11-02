using UnityEngine;
using System.Collections;


public class MapCollision: MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name == "character") {
			foreach(GameObject child in gameObject.transform) {
				if (child.gameObject.tag == "Enemy") {
					child.gameObject.GetComponent<Enemy>().setActivate (true);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.name == "character") {
			foreach (GameObject child in gameObject.transform) {
				if (child.gameObject.tag == "Enemy") {
					child.gameObject.GetComponent<Enemy>().setActivate (false);
				}
			}
		}
	}
}