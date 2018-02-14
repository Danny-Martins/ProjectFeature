using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyController : MonoBehaviour {

	[SerializeField] protected float health = 1;
	/// move speed in units per frame
	[SerializeField] protected float move_speed = 1;

	virtual protected void OnTriggerEnter(Collider other_collider){
		if(other_collider.tag != "Enemy Finishline")
			return;

		Destroy(this.gameObject);
		//lose lives/gameover
	}

}
