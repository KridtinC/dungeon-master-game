using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorController : MonoBehaviour{
  public PlayerController player;
	private float dist;
	private float minDist = 2f;
	private string text = "Press 'F' to activate timer. Then, go to read riddle at 'Capsule'";
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
      GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 150, 50), text);
      }
    }
}