using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] protected float health = 1;
	/// move speed in units per frame
	[SerializeField] protected float move_speed = 1;

	[SerializeField] protected Vector3 target = Vector3.zero;

	Rigidbody rigid = null;

	byte path_node_index = 1;
	[SerializeField] Transform[] path_nodes = null;

	void Start(){
		Destroy(this.gameObject, 30.0f);

		path_nodes = GameObject.Find("Path Nodes").transform.GetComponentsInChildren<Transform> ();

		this.rigid = this.GetComponent<Rigidbody> ();

		this.target = this.path_nodes[1].position;
		this.set_velocity();
	}

	void Update(){
//		if(this.is_near_point(this.target, 0.25f)){
//			this.path_node_index++;
//			this.target = this.path_nodes[this.path_node_index].position;
//			this.set_velocity();
//		}
//		print(this.rigid.velocity);
	}

	void set_velocity(){

		this.rigid.velocity = target - this.transform.position;
		this.rigid.velocity *= this.move_speed;
		//Debug.Break();
		//Vector3 difference_vector = path_nodes[path_node_index].position - this.transform.position;
		//this.rigid.velocity = new Vector3(Mathf.Sin(difference_vector.x), 0.0f, Mathf.Tan(difference_vector.z));
		//this.rigid.velocity *= this.move_speed;
	}

	virtual protected void OnTriggerEnter(Collider other_collider){
		if(other_collider.tag == "Enemy Finishline"){
			Player.player.lives --;
			Destroy(this.gameObject);
		}

		if(other_collider.tag == "Path"){
			this.path_node_index++;
			this.target = this.path_nodes[this.path_node_index].position;
			this.set_velocity();
		}

//		Destroy(this.gameObject);
	}

	protected bool is_near_point(Vector3 point, float precision){
		Vector2 difference_vector = point - this.transform.position;
		return (difference_vector.magnitude < precision);
	}

}
