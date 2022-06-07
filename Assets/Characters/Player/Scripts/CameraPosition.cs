using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPosition : MonoBehaviour
{


    private CinemachineVirtualCamera _camera;
    public Vector3 CameraPositionDefault;
    
    


    private void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
       
    }

   

    public void SwitchPosition(Vector3 pos, Quaternion rotation, Transform lookTarget = null)
    {
        _camera.LookAt = lookTarget;
        _camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = pos;
        _camera.transform.rotation = rotation;
    }
}
