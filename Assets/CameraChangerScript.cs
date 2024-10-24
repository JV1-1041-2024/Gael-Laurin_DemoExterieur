using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChangerScript : MonoBehaviour
{
    [SerializeField] public List<CinemachineVirtualCamera> cams;
    public void ChangeCamera(int i = 0)
    {
        foreach (var cam in cams)
        {
            if (cam == cams[i])
            {
                cam.Priority = 11;
            } else
            {
                cam.Priority = 10;
            }
        }
    }
}
