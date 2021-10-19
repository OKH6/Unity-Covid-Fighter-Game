using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private CinemachineComposer composer;
    [SerializeField]
    private float sensetivty=1f;

    void Start()
    {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();

        
    }

    void Update()
    {
        float v = Input.GetAxis("Mouse Y") * sensetivty;
        composer.m_TrackedObjectOffset.y += v;
        float v1 = Mathf.Clamp(composer.m_TrackedObjectOffset.y,0, 10);
        composer.m_TrackedObjectOffset.y = v1;

        //Debug.Log(composer.m_TrackedObjectOffset.y);



    }
}
