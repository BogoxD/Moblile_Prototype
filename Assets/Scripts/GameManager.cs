using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject TrebuchetPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float resetTrebuchetDelay;

    private Projectile projectile;

    private void Awake()
    {
        projectile = FindObjectOfType<Projectile>();
    }
    private void FixedUpdate()
    {
        if (!projectile)
            Invoke(nameof(ResetTrebuchet), resetTrebuchetDelay);
        else
            CancelInvoke(nameof(ResetTrebuchet));
    }
    private void ResetCameras(TrebuchetController trebuchet)
    {
        trebuchet.CameraFollowScript.gameObject.SetActive(true);
        trebuchet.CameraViewScript.gameObject.SetActive(true);
    }
    private void ResetTrebuchet()
    {
        GameObject currenTrebuchet = FindObjectOfType<TrebuchetController>().gameObject;
        Vector3 currentRotation = currenTrebuchet.transform.rotation.eulerAngles;

        ResetCameras(currenTrebuchet.GetComponent<TrebuchetController>());
        Destroy(currenTrebuchet);

        GameObject newTrebuchet = Instantiate(TrebuchetPrefab, spawnPoint.position, Quaternion.Euler(currentRotation));

        newTrebuchet.transform.SetParent(null);
        newTrebuchet.transform.Rotate(Vector3.up, currentRotation.y);

        projectile = newTrebuchet.GetComponentInChildren<Projectile>();

    }
}
