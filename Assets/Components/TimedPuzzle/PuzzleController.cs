using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
	public bool completed;
	public TimeController time;
	public GameObject obj;
	private float duration = 3f;
	// Start is called before the first frame update
	void Start()
	{
			
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F)){
					// Puzzle.Activate
			time.timeRun = true;
			}
		if (Input.GetKeyDown(KeyCode.R)){
			completed = true;
		}
		if(completed && time.timeValue >= 0f){
			if(duration >= 0f){
				obj.transform.position = obj.transform.position + new Vector3(0, 1f * Time.deltaTime, 0);
				duration -= Time.deltaTime;
			}
		}
	}
}
