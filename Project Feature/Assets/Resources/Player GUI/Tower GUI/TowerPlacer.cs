using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour {

	[SerializeField] Tower tower_prefab = null;

	GameObject prefab_instance = null;
	bool is_placing_tower = false;

	public void OnClick(){
		if(!this.is_placing_tower){
			this.is_placing_tower = true;
			this.prefab_instance = (GameObject)Instantiate(this.tower_prefab.gameObject);
			//Cursor.visible = false;
		}
	}

	public void Update(){

		//print(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0.0f, Input.mousePosition.y)));
		//print(Input.mousePosition.y);

		if(!this.is_placing_tower)
				return;

		if(Input.GetKeyDown(KeyCode.Escape)){
			Destroy(this.prefab_instance);
			this.is_placing_tower = false;
			//Cursor.visible = true;
		}

//		if(Input.GetMouseButtonDown(0)){
//			this.OnClick();
//		}

		//swapped the y and z due to camera rotation
		Vector3 tower_place_position = Camera.main.ScreenToWorldPoint
			(new Vector3(Input.mousePosition.x, 0.0f, Input.mousePosition.y));

		tower_place_position.z *= -1;
		tower_place_position.y = 0.0f;

		this.prefab_instance.transform.position = tower_place_position;

		//this.prefab_instance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//this.prefab_instance.transform.position = Input.mousePosition;
		//print(this.prefab_instance.transform.position);

	}

	void check_path_intersects(){
		if(GameController.game_mode == GameController.GAME_MODES.Classic)
			return;

		
	}

}
