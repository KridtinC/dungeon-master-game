using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour{
	public bool completed = false;
	public TimeController time;
	public GameObject obj;
	private float duration = 1.5f;
	public PlayerController player;
	// Start is called before the first frame update
	void Start(){
	}
	// Update is called once per frame
	void Update(){
		if(completed){
			if(duration >= 0f){
				obj.transform.Translate(0, -1f * Time.deltaTime, 0);
				duration -= Time.deltaTime;
			}
		}
	}
}