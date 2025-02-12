using UnityEngine;
using System.Collections;

public class DieOnPlayerBulletHit : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 9) { // player bullets
			// Die
			Destroy(this.gameObject);
			// Also destroy the player's bullet
			Destroy(other.gameObject);
		}
	}
}
