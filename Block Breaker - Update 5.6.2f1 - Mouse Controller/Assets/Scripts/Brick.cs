using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject smoke;
	public static int breakableCount = 0;
	
	private int timesHit;	
	private LevelManager levelManager;		
	private bool isBreakable ;
	
	void Start () {
		//Keep tracks of Breakable Bricks.
		isBreakable = (this.tag == "Breakable");
		if(isBreakable)	breakableCount++;	
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionExit2D(Collision2D collision){
		//It plays audio even if the brick is destroyed at the position of the brick.
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.25f);
        if (isBreakable) { 
                HandleHits();
        }
    }
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();	
			PuffSmoke();		
			Destroy(gameObject);
		} 
		else{
			LoadSprites();
		}
	}
	
	void PuffSmoke(){		
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		ParticleSystem smokePuffPS = smokePuff.GetComponent<ParticleSystem> ();
		var smokePuffMain = smokePuffPS.main;
		smokePuffMain.startColor = this.GetComponent<SpriteRenderer>().color;
		Destroy (smokePuff, 0.7f);
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		//If the array doesn't have a sprite the code doesn't loads it.
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else{
			Debug.LogError("Missing Sprite: There is no Sprite to load.");
		}
	}
	
	//TODO Remove this method once we can actually win
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
