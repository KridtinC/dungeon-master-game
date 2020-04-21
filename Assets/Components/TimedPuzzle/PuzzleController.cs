using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
	public bool completed;
	private bool opened;
	public TimeController time;
	// Start is called before the first frame update
	void Start()
	{
			
	}

	// Update is called once per frame
	void Update()
	{
		// if(puzzle solve){
		//	setCompleted(true);
		// }
		if (Input.GetKeyDown(KeyCode.F)){
			setCompleted(true);
		}
		if(!time.IsTimeRun() && !completed){
			this.opened = false;
		}
		// if(completed){
		// 	this.opened = true;
		// 	time.addTime(30f);
		// }

	}
	public void setCompleted(bool x){
		this.completed = x;
	}
}
