using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	
	void Start () {
		//<> Works as a filter to find a specific object.
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	void Update () {
		if(!hasStarted){
			//Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//Wait for a mouse press to launch.
			if(Input.GetMouseButtonDown(0)){
				GetComponent<AudioSource>().Play();
				hasStarted = true;
				//print ("Mouse clicked, launching ball");
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}
	
	void OnCollisionExit2D(Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		if(hasStarted){
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;	
		}
	}
}