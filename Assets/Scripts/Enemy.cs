using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int health;

	private bool activate = false;

	void Start()
    {
    
    }

	void Update() {
		if (this.health == 0) {
			Destroy (gameObject);
		}
		if (this.activate) {
			// add movement here
			Debug.Log("Hello!");
		}
	}
	public bool getActivate() {
		return activate;	
	}
	public void setActivate(bool con) {
		this.activate = con;
	}

}