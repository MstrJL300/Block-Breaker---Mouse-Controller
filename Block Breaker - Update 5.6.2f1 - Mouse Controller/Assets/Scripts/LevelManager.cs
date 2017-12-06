using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	void Start(){
		//print ("Active Scene: " + SceneManager.GetActiveScene ().buildIndex);
	}

	public void LoadLevel(string name){
		//Application.LoadLevel(name);	
		SceneManager.LoadScene(name);	
		Brick.breakableCount = 0;
	}
	
	public void QuitRequest(){
		Debug.Log("I want to quit!");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		//This will automatically load the next level in the sequence of the build.
		//Application.LoadLevel(Application.loadedLevel + 1);
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
		Brick.breakableCount = 0;
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0) LoadNextLevel();
	}
}