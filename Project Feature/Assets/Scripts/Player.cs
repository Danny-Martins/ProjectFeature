using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	static public Player player = null;

	[SerializeField] Text lives_gui = null;
	public int lives = 1;

	[SerializeField] Text mana_gui = null;
	[SerializeField] float current_mana = 1;
	[SerializeField] float max_mana = 1;
	public float mana_regen = 0.05f;

	[SerializeField] Text gold_gui = null;
	public int gold = 1;

	void Awake(){
		if(!Player.player)
			Player.player = this;
	}

	void Start(){
		this.lives_gui = GetComponentsInChildren<Text> ()[2];
		this.mana_gui = GetComponentsInChildren<Text> ()[1];
		this.gold_gui = GetComponentsInChildren<Text> ()[0];

//		this.lives_gui.text = "lives";
//		this.mana_gui.text = "mana";
//		this.gold_gui.text = "gold";
	}

	void Update(){

		this.current_mana += this.mana_regen * Time.deltaTime;
		this.current_mana = Mathf.Min(this.current_mana, this.max_mana);
		this.mana_gui.text = "" + (int)this.current_mana;

		this.lives_gui.text = "" + this.lives;
		this.gold_gui.text = "" + this.gold;

	}

	public void lose_live(int lives_lost){
		this.lives -= lives_lost;
		if(this.lives <= 0)
			Application.Quit();
	}

}
