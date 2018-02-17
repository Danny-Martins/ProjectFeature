using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public List<Transform> path_nodes = null;
	[SerializeField] Transform initial_spawn_override = null;

	[SerializeField] EnemyController test_spawn_enemy = null;



	public void spawn_enemy(){
		
	}

	void OnDrawGizmos(){
		for(byte i=1; i<path_nodes.Count;i++){
			Gizmos.color = Color.red;
			Gizmos.DrawCube(this.path_nodes[i-1].position, Vector3.one);
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.path_nodes[i-1].position, this.path_nodes[i].position);
		}
	}

}
