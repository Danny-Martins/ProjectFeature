using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public List<Transform> path_nodes = null;
	[SerializeField] Transform initial_spawn_override = null;
	[SerializeField] EnemyController test_spawn_enemy = null;

	[SerializeField] float spawn_interval = 1.0f;

	void Start(){
		InvokeRepeating("spawn_enemy", 1.0f, this.spawn_interval);
	}

	public void spawn_enemy(){
		Instantiate(this.test_spawn_enemy, initial_spawn_override.position, Quaternion.identity);
	}

	void OnDrawGizmos(){
		for(byte i=0; i<path_nodes.Count;i++){
			Gizmos.color = Color.red;
			Gizmos.DrawCube(this.path_nodes[i].position, Vector3.one);
			if(i+1 == path_nodes.Count)
				return;
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.path_nodes[i+1].position, this.path_nodes[i].position);
		}
	}

}
