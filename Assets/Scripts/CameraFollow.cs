using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    Projectile projectile;
    CinemachineVirtualCamera virtualCamera;
    
    //Setup Cinemachine to follow the projecitle every trebuchet reset
    public void FindProjectile()
    {
        gameObject.SetActive(true);
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        projectile = FindObjectOfType<Projectile>();

        if(projectile)
        {
            virtualCamera.Follow = projectile.transform;
            virtualCamera.LookAt = projectile.transform;
        }
    }
}
