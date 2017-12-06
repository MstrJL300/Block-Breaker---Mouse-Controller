using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public AudioClip gameMusic;
    public AudioClip menuMusic;
    public AudioClip gameOver;
    public AudioClip win;

    static MusicPlayer instance = null;

    private AudioSource aSo;

    string currentLevel = "Start";

    void Awake(){
        aSo = GetComponent<AudioSource>();
        //Debug.Log("Music player Awake " + GetInstanceID());
        //If any other instance exists we destroy the duplicate.
        if (instance){
			Destroy(gameObject);
			print ("Destroyed");
		}
		//If no instance exists we create a new one.
		else{
			instance = this;
			//This avoids the GameObject from disappearing when it moves from one scene to another.
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

    void Update() {
        ChangeClip();
    }

    public void ChangeClip() {
        //If the scene changes then we change the clip of the Audio Source.
        if (currentLevel != SceneManager.GetActiveScene().name) {
            if (SceneManager.GetActiveScene().name == "Start") {
                aSo.clip = menuMusic;
            }
            else if (SceneManager.GetActiveScene().name.StartsWith("Level_")) {
                aSo.clip = gameMusic;
            }
            else if (SceneManager.GetActiveScene().name == "Lose") {
                aSo.clip = gameOver;
            }
            else if (SceneManager.GetActiveScene().name == "Win") {
                aSo.clip = win;
            }

            //These are the scenes were I want the clip to loop.
            if (!aSo.loop &&
                (SceneManager.GetActiveScene().name == "Start" || SceneManager.GetActiveScene().name.StartsWith("Level_"))) {
                aSo.loop = true;
            }
            //These are the scenes were I don't want the clip to loop.
            else if (aSo.loop &&
                (SceneManager.GetActiveScene().name == "Lose" || SceneManager.GetActiveScene().name == "Win")) {
                aSo.loop = false;
            }

            //Every time we change the clip we need to replay the AudioSource.
            aSo.Play();

            //We change the variable with name of the current level to make these changes only once.
            currentLevel = SceneManager.GetActiveScene().name;
        }
    }
}