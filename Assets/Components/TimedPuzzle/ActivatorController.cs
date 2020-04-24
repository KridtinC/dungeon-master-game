using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorController : MonoBehaviour{
  public PlayerController player;
	private float dist;
	private float minDist = 2f;
	private string text = "Press 'F' to activate timer and read riddle";
  public TimeController time;
  public GameObject button;
    // Start is called before the first frame update
    void Start(){
    }
    // Update is called once per frame
    void Update(){
    if (dist <= minDist && Input.GetKeyDown(KeyCode.F)){
		  time.timeRun = true;
		}
    else{
      dist = Vector3.Distance(player.transform.position, button.transform.position);
    }
    }
    void OnGUI(){
    if (dist <= minDist){
      GUI.TextArea(new Rect(50, 100, 100, 50), text);
    }
  }
}