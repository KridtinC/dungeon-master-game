using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	public Text TimeLeft;
	public float time = 60f;
	public bool timeRun = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		timing();
		TimeLeft.text = time.ToString("f1");
	}

	void TimeCount(){
		time -= Time.deltaTime;
	}
	float TimeStop(){
		return time;
	}
	private void timing(){
		if (Input.GetKeyDown(KeyCode.F)){
					// Puzzle.Activate
				timeRun = !timeRun;
				}
		if(timeRun){
			TimeCount();
			}
		else{
			TimeStop();
			}
	}
}
