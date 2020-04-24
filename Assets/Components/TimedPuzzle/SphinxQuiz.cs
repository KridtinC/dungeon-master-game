using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphinxQuiz : MonoBehaviour{
	public GameObject Quiz;
	public GameObject Ans1;
	public GameObject Ans2;
	public GameObject Ans3;
	public PlayerController player;
	private float dist = 3f;
	private float distA = 3f;
	private float distB = 3f;
	private float distC = 3f;
	private float minDist = 2f;
	private List<string> Answer = new List<string>{"Memory","Name","Joke"};
	private string A1;
	private string A2;
	private string A3;
	private string text;
	public TimeController time;
	public PuzzleController puzzle;
	// Start is called before the first frame update
	void Start(){
		A1 = Answer[Random.Range(0, Answer.Count)];
		Answer.Remove(A1);
		// Answer.IndexOf("Item");
		A2 = Answer[Random.Range(0, Answer.Count)];
		Answer.Remove(A2);
		A3 = Answer[0];
	}
	// Update is called once per frame
	void Update(){
		if(time.timeRun){
			if(!puzzle.completed){
				dist = Vector3.Distance(player.transform.position, Quiz.transform.position);
				distA = Vector3.Distance(player.transform.position, Ans1.transform.position);
				distB = Vector3.Distance(player.transform.position, Ans2.transform.position);
				distC = Vector3.Distance(player.transform.position, Ans3.transform.position);
				}
			if(Input.GetKeyDown(KeyCode.R)){
				if(distA <= minDist && A1 == "Memory"){
					puzzle.completed = true;
					time.multipiler = 1;
					}
				else if(distB <= minDist && A2 == "Memory"){
					puzzle.completed = true;
					time.multipiler = 1;
					}
				else if(distC <= minDist && A3 == "Memory"){
					puzzle.completed = true;
					time.multipiler = 1;
					}
				else{
					time.multipiler = 2;
				}
			}
		}
	}
	void OnGUI(){
		if(time.timeRun && !puzzle.completed){
			if (dist <= minDist){
				GUI.TextArea(new Rect(200, 200, 200, 100),"What can bring back the dead; make you cry, make you laugh, make you young; "
				+ "is born in an instant, yet lasts a lifetime. Press 'R' near a pillar to Answer.");
				}
			else if (distA <= minDist){
				GUI.TextArea(new Rect(100, 100, 60, 30), A1);
				}
			else if (distB <= minDist){
				GUI.TextArea(new Rect(100, 100, 60, 30), A2);
				}
			else if (distC <= minDist){
				GUI.TextArea(new Rect(100, 100, 60, 30), A3);
				}
			}
		}
}