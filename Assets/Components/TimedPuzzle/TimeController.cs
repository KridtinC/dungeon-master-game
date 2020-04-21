using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	public Text TimeLeft;
	public float timeValue = 60f;
	public bool timeRun = false;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		timing();
		TimeLeft.text = timeValue.ToString("f1");
	}

	public void TimeCount(){
		timeValue -= Time.deltaTime;
	}
	public float TimeStop(){
		return timeValue;
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
		if(timeValue <= 0f){
			SetTimeRun(false);
		}
	}
	public bool IsTimeRun(){
		return timeRun;
	}
	public void SetTimeRun(bool x){
		timeRun = x;
	}
	public void addTime(float x){
		timeValue += x;
	}
}
