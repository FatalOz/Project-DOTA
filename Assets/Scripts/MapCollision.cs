using UnityEngine;
using System.Collections;
using Enemy.cs;

public class MapCollision: MonoBehaviour {
	
	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "character") {
			Enemy.activate = true;
		}
	}
	
}