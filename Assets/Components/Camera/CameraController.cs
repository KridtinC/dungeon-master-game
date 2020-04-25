using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;

    protected Vector3 target_camera_translation;

    // Start is called before the first frame update
    void Start()
    {
        target_camera_translation = new Vector3(0, 15, -10);
        transform.rotation = Quaternion.LookRotation(-target_camera_translation, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + target_camera_translation;
    }
}
