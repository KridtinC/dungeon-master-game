using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCameraController : MonoBehaviour
{

    public GameObject target_p;
    protected Vector3 target_camera_translation_p;

    // Start is called before the first frame update
    void Start()
    {
        target_camera_translation_p = new Vector3(0, 6, -4);
        transform.rotation = Quaternion.LookRotation(-target_camera_translation_p, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target_p.transform.position + target_camera_translation_p;
    }
}
