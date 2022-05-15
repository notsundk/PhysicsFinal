using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCycle : MonoBehaviour
{
    [SerializeField]
    private Camera[] cameras = new Camera[3];
    int activeCameraIdx = 0;

    void Start()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = false;
        }
        cameras[0].enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Cycleme(1);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Cycleme(-1);
    }

    private void Cycleme(int updown)
    {
        cameras[activeCameraIdx].enabled = false;
        activeCameraIdx = activeCameraIdx + updown;
        if (activeCameraIdx >= cameras.Length)
        {
            activeCameraIdx = 0;
        }
        else if (activeCameraIdx < 0)
        {
            activeCameraIdx = cameras.Length - 1;
        }
        cameras[activeCameraIdx].enabled = true;
    }
}
