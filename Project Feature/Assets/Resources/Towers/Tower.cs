using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

abstract public class Tower : MonoBehaviour {

	[SerializeField] protected float damage = 1;
	[SerializeField] protected float range = 1;
	/// rate of fire per second
	[SerializeField] protected float fire_rate = 1;

	[SerializeField] protected List<EnemyController> targets_in_range = null;
	[SerializeField] protected EnemyController current_target = null;

	protected bool can_shoot = true;

	virtual protected void Start(){
		this.targets_in_range = new List<EnemyController> ();
	}

	virtual protected void OnTriggerEnter(Collider other_collider){
		if(other_collider.tag != "Enemy")
			return;

		EnemyController enemy = other_collider.GetComponent<EnemyController> ();

		this.targets_in_range.Add(enemy);

		if(!this.current_target)
			this.current_target = enemy;
	}

	virtual protected void OnTriggerExit(Collider other_collider){
		if(other_collider.tag != "Enemy")
			return;

		EnemyController enemy = other_collider.GetComponent<EnemyController> ();

		if(this.current_target == enemy){
			this.current_target = null;
			this.retarget();
			return;
		}

		try{
			this.targets_in_range.Remove(enemy);
		}
		catch (Exception exception){
			throw new NotImplementedException();
		}

	}

	virtual protected IEnumerator reload(){
		yield return new WaitForSeconds(this.fire_rate);
		this.can_shoot = true;
	}

	virtual protected void retarget(){
		if(this.current_target || this.targets_in_range.Count == 0)
			return;

		foreach (EnemyController enemy in this.targets_in_range){
			if(!enemy){
				this.targets_in_range.Remove(enemy);
				continue;
			}
				
			this.current_target = enemy;
			return;
		}
	}

}
