using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceQuiz : MonoBehaviour{
  public GameObject Quiz;
	public GameObject B1;
	public GameObject B2;
	public GameObject B3;
  public GameObject B4;
	public PlayerController player;
	private float dist = 3f;
	private float dist1 = 3f;
	private float dist2 = 3f;
	private float dist3 = 3f;
  private float dist4 = 3f;
	private float minDist = 2f;
	private string text;
	public TimeController time;
	public PuzzleController puzzle;
  private List<string> seq0 = new List<string>();
  private List<string> seq1 = new List<string>();
  // Start is called before the first frame update
  void Start(){
    for(int i = 0; i < 6; i++){
      seq0.Add((Random.Range(1,5)).ToString());
    }
  }
  // Update is called once per frame
  void Update(){
    if(time.timeRun){
      if(!puzzle.completed){
        dist = Vector3.Distance(player.transform.position, Quiz.transform.position);
        dist1 = Vector3.Distance(player.transform.position, B1.transform.position);
        dist2 = Vector3.Distance(player.transform.position, B2.transform.position);
        dist3 = Vector3.Distance(player.transform.position, B3.transform.position);
        dist4 = Vector3.Distance(player.transform.position, B4.transform.position);
        }
      if(Input.GetKeyDown(KeyCode.R)){
        if(dist1 <= minDist){
          seq1.Add("1");
          }
        else if(dist2 <= minDist){
          seq1.Add("2");
          }
        else if(dist3 <= minDist){
          seq1.Add("3");
          }
        else if(dist4 <= minDist){
          seq1.Add("4");
          }
        }
      if(seq0.Count == seq1.Count){
        for(int i = 0; i < 6; i++){
          if(seq0[i] != seq1[i]){
            seq1.Clear();
            time.multipiler = 2;
            break;
            }
          }
        if(seq1.Count == 6){
          puzzle.completed = true;
          time.multipiler = 1;
          seq1.Clear();
          }
        }
      }
      else{
        seq1.Clear();
        }
      }
  	void OnGUI(){
      if(time.timeRun && !puzzle.completed){
        if (dist <= minDist){
          GUI.TextArea(new Rect(200, 200, 200, 100), "press 'R' nearby pi''ar by following order "
          +string.Join(",", seq0.ToArray())+"\n"+string.Join(",", seq1.ToArray()));
          }
        else if (dist1 <= minDist){
          GUI.TextArea(new Rect(50, 100, 50, 50), "1");
          }
        else if (dist2 <= minDist){
          GUI.TextArea(new Rect(50, 100, 50, 50), "2");
          }
        else if (dist3 <= minDist){
          GUI.TextArea(new Rect(50, 100, 50, 50), "3");
          }
        else if (dist4 <= minDist){
          GUI.TextArea(new Rect(50, 100, 50, 50), "4");
          }
        }
  }
}
