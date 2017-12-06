﻿//TODO Enlarge the paddle to 56
using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	public float minX, maxX;
	
	private Ball ball;
	
	void Start (){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () {
		if(!autoPlay) MoveWithMouse();
		else AutoPlay();
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x/Screen.width*16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
}
