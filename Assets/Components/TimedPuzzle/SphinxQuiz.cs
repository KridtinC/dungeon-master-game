using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphinxQuiz : MonoBehaviour{

	public GameObject Quiz;
	public GameObject Ans1;
	public GameObject Ans2;
	public GameObject Ans3;
	public PlayerController player;
	public float dist = 3f;
	public float distA = 3f;
	public float distB = 3f;
	public float distC = 3f;
	private float minDist = 2f;
	private string text;
	public TimeController time;
	public PuzzleController puzzle;
	// Start is called before the first frame update
	void Start()
	{		
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
				if(distB <= minDist){
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
				+ "is born in an instant, yet lasts a lifetime. Press 'R' near pillar to Answer.");
			}
			if (distA <= minDist){
				GUI.TextArea(new Rect(50, 100, 150, 50), "Name");
			}
			if (distB <= minDist){
				GUI.TextArea(new Rect(50, 100, 150, 50), "Memory");
			}
			if (distC <= minDist){
				GUI.TextArea(new Rect(50, 100, 150, 50), "Joke");
			}
		}
		}
		
}