using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	public Text TimeLeft;
	public float timeValue;
	public bool timeRun = false;
	// Start is called before the first frame update
	void Start()
	{
		setTimeOrigin();
	}

	// Update is called once per frame
	void Update()
	{
		timing();
		TimeLeft.text = timeValue.ToString("f1");
	}
	private void TimeCount(){
		timeValue -= Time.deltaTime;
	}
	public float TimeStop(){
		return timeValue;
	}
	private void timing(){
		if(timeRun){
			TimeCount();
			}
		else{
			TimeStop();
			setTimeOrigin();
		}
		if(timeValue < 0f){
			timeRun = false;
		}
	}
	public void setTimeOrigin(){
		timeValue = 10f;
	}
}
