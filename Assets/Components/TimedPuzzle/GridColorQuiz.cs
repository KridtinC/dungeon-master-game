using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridColorQuiz : MonoBehaviour{
  public GameObject Quiz;
	public GameObject F1;
	public GameObject F2;
	public GameObject F3;
  public GameObject F4;
  public GameObject F5;
	public GameObject F6;
	public GameObject F7;
  public GameObject F8;
  public GameObject F9;
	public PlayerController player;
	private float dist = 3f;
	private float dist1 = 3f;
	private float dist2 = 3f;
	private float dist3 = 3f;
  private float dist4 = 3f;
	private float dist5 = 3f;
	private float dist6 = 3f;
	private float dist7 = 3f;
  private float dist8 = 3f;
  private float dist9 = 3f;
	private float minDist = 2f;
	private string text;
	public TimeController time;
	public PuzzleController puzzle;
  private Renderer RGB;
  private List<Color> trueGrid = new List<Color>();
  private List<Color> colorGrid = new List<Color>{Color.red,Color.green,Color.blue};
  private bool[] grid = new bool[9];
  private bool pass = false;
  // Start is called before the first frame update
    void Start(){
      for(int i = 0; i < 9; i++){
        trueGrid.Add(colorGrid[Random.Range(0, colorGrid.Count)]);
      }
    }
    // Update is called once per frame
    void Update(){
      if(time.timeRun){
        if(!puzzle.completed){
          dist = Vector3.Distance(player.transform.position, Quiz.transform.position);
          dist1 = Vector3.Distance(player.transform.position, F1.transform.position);
          dist2 = Vector3.Distance(player.transform.position, F2.transform.position);
          dist3 = Vector3.Distance(player.transform.position, F3.transform.position);
          dist4 = Vector3.Distance(player.transform.position, F4.transform.position);
          dist5 = Vector3.Distance(player.transform.position, F5.transform.position);
          dist6 = Vector3.Distance(player.transform.position, F6.transform.position);
          dist7 = Vector3.Distance(player.transform.position, F7.transform.position);
          dist8 = Vector3.Distance(player.transform.position, F8.transform.position);
          dist9 = Vector3.Distance(player.transform.position, F9.transform.position);
          }
        if(Input.GetKeyDown(KeyCode.R)){
          if(dist1 <= minDist){
            changeRGB(F1);
            checkColor(0);
            }
          else if(dist2 <= minDist){
            changeRGB(F2);
            checkColor(1);
            }
          else if(dist3 <= minDist){
            changeRGB(F3);
            checkColor(2);
            }
          else if(dist4 <= minDist){
            changeRGB(F4);
            checkColor(3);
            }
          else if(dist5 <= minDist){
            changeRGB(F5);
            checkColor(4);
            }
          else if(dist6 <= minDist){
            changeRGB(F6);
            checkColor(5);
            }
          else if(dist7 <= minDist){
            changeRGB(F7);
            checkColor(6);
            }
          else if(dist8 <= minDist){
            changeRGB(F8);
            checkColor(7);
            }
          else if(dist9 <= minDist){
            changeRGB(F9);
            checkColor(8);
            }
          }
        foreach(bool b in grid){
          if(b){
            pass = true;
          }
          else{
            pass = false;
            break;
          }
        }
        if(pass){
          puzzle.completed = true;
        }
      }
    }
    void OnGUI(){
      if(time.timeRun && !puzzle.completed){
        if (dist <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 200, 50), "press 'R' near a cube to change into color from text");
        }
        else if (dist1 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[0]));
        }
        else if (dist2 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[1]));
        }
        else if (dist3 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[2]));
        }
        else if (dist4 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[3]));
        }
        else if (dist5 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[4]));
        }
        else if (dist6 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[5]));
        }
        else if (dist7 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[6]));
        }
        else if (dist8 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[7]));
        }
        else if (dist9 <= minDist){
          GUI.TextArea(new Rect(Screen.width * 0.125f, Screen.width * 0.125f, 50, 30), RGBstring(trueGrid[8]));
        }
      }
		}
    private void changeRGB(GameObject obj){
      RGB = obj.GetComponent<Renderer>();
      if(RGB.material.color == Color.white){
          RGB.material.color = Color.red;
      }
      else if(RGB.material.color == Color.red){
          RGB.material.color = Color.green;
      }
      else if(RGB.material.color == Color.green){
          RGB.material.color = Color.blue;
      }
      else if(RGB.material.color == Color.blue){
          RGB.material.color = Color.white;
      }
    }
    private void checkColor(int i){
      if(RGB.material.color == trueGrid[i]){
        grid[i] = true;
        }
      else{
        grid[i] = false;
      }
    }
    private string RGBstring(Color x){
      if(x == Color.red){
        return "Red";
      }
      else if(x == Color.green){
        return "Green";
      }
      else if(x == Color.blue){
        return "Blue";
      }
      return "White";
    }
}
