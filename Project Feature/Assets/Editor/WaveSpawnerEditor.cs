using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaveSpawner))]
public class WaveSpawnerEditor : Editor {

	public override void OnInspectorGUI (){
		DrawDefaultInspector();

		WaveSpawner wave_spawner = (WaveSpawner)target;

		if(GUILayout.Button("Spawn Enemy")){
			wave_spawner.spawn_enemy();
		}

	}
}
