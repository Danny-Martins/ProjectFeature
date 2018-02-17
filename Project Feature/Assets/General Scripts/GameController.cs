using UnityEngine.SceneManagement;
using UnityEngine;

static public class GameController{

	static public Object load(string path){
		Object wanted_object = Resources.Load(path);
		if(!wanted_object){
			Debug.LogError("Error cannot find object at : " + path);
			Debug.Break();
			return null;
		}
		return wanted_object;
	}

	//change this later to load async then close current scene while bringing up loading screen
	static public void load_new_scene(string scene_name, bool close_current = true){
		if(close_current){
			SceneManager.LoadScene(scene_name);
			Resources.UnloadUnusedAssets();
		}
		else
			SceneManager.LoadSceneAsync(scene_name);
	}
}
