using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start () {
		//<> Works as a filter to find a specific object.
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		print ("Collider");
		levelManager.LoadLevel("Lose");
	}
}