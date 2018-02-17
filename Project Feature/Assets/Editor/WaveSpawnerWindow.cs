using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaveSpawnerWindow : EditorWindow {

	WaveSpawner wave_spawner_gameobject = null;

	bool uses_path = false;

	GameObject path_nodes_root = null;

	[MenuItem("Window/Wave Spawner")]
	static public void ShowWindow(){
		WaveSpawnerWindow window = (WaveSpawnerWindow)EditorWindow.GetWindow(typeof(WaveSpawnerWindow));
		window.Start();
	}

	//non built in init function
	void Start(){
		Debug.Log("start ran");

		this.path_nodes_root = GameObject.Find("Path Nodes");
		this.wave_spawner_gameobject = GameObject.Find("Wave Spanwer").GetComponent<WaveSpawner>();
	}

	void OnGUI(){

		if(GUILayout.Button("Create Path Node Root")){
			if(this.path_nodes_root)
				Debug.Log("Path Root not created, it already exists");
			else{
				this.path_nodes_root = new GameObject("Path Nodes");
			}
		}

		uses_path = EditorGUILayout.BeginToggleGroup("Uses Path Nodes", uses_path);

		if(uses_path && !this.path_nodes_root){
			Debug.LogError("Path parent missing");
			uses_path = false;
		}

		if(GUILayout.Button("Create Path Node")){
			this.create_path_node();
		}

		//some_number = EditorGUILayout.Slider("float number", some_number, 0, 10);
		//some_bool = EditorGUILayout.Toggle("bool value", some_bool);
		EditorGUILayout.EndToggleGroup();

		if(GUILayout.Button("Spawn Enemy")){
			//Debug.Log("button clicked " + this.some_number + " bool: " + this.some_bool);
		}

	}

	void create_path_node(){
		GameObject node = new GameObject("Node");
		node.transform.parent = this.path_nodes_root.transform;
		node.transform.position = this.wave_spawner_gameobject.path_nodes[this.wave_spawner_gameobject.path_nodes.Count-1].position;
		this.wave_spawner_gameobject.path_nodes.Add(node.transform);
		Selection.activeGameObject = node;
	}

}
