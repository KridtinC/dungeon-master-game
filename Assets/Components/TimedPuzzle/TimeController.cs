using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour{
	public Text TimeLeft;
	public float timeValue;
	public bool timeRun = false;
	public int multipiler = 1;
	// Start is called before the first frame update
	void Start(){
		TimeLeft.enabled = false;
		setTimeOrigin();
		}
	// Update is called once per frame
	void Update(){
		timing();
		TimeLeft.text = timeValue.ToString("f1");
		}

	private void TimeCount(){
		TimeLeft.enabled = true;
		timeValue -= multipiler*Time.deltaTime;
		}

	public float TimeStop(){
		multipiler = 1;
		TimeLeft.enabled = false;
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
		timeValue = 60f;
		}
}