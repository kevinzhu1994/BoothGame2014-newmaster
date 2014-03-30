﻿using UnityEngine;
using System.Collections;

public class Gandalf : MonoBehaviour {
	// Set these in the inspector
	public float spellRadius;
	public float spellPower;
	
	void Update () {
		processInput();
	}

	private void processInput() {
		if (Input.GetKeyDown(KeyCode.A) ||
		    Input.GetKeyDown(KeyCode.B) ||
		    Input.GetKeyDown(KeyCode.X) ||
		    Input.GetKeyDown(KeyCode.Y)){

			castBigSpell();
		}
	}

	private void castBigSpell() {
		Collider[] hits = Physics.OverlapSphere(transform.position, spellRadius);

		for (int i = 0; i < hits.Length; i++) {
			if (hits[i].transform.GetComponents(typeof(Ally)).Length > 0) continue;

			if (hits[i].attachedRigidbody) {
				hits[i].attachedRigidbody.AddExplosionForce(spellPower, transform.position, spellRadius);
			}

			Component[] ls = hits[i].transform.GetComponents(typeof(Lockable));
			if (ls.Length > 0) {
				((Lockable)ls[0]).onFire();
			}
		}
	}
}
