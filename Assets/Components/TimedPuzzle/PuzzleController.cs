using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour{
	private bool completed;
	public TimeController time;
	public GameObject obj;
	private float duration = 2f;
	private float dist;
	private float minDist = 2f;
	private string text = "Press 'R' to completed.";
	public PlayerController player;
	// Start is called before the first frame update
	void Start(){
			completed = false;
	}
	// Update is called once per frame
	void Update(){
		if (dist <= minDist && time.timeValue >= 0f && Input.GetKeyDown(KeyCode.R)){
			completed = true;
		}
		if(completed){
			if(duration >= 0f){
				obj.transform.position = obj.transform.position + new Vector3(0, 1f * Time.deltaTime, 0);
				duration -= Time.deltaTime;
			}
		}
		else{
			dist = Vector3.Distance(player.transform.position, obj.transform.position);
		}
	}
	void OnGUI(){
    if (dist <= minDist && !completed){
      GUI.TextArea(new Rect(50, 100, 150, 50), text);
    }
  }
}