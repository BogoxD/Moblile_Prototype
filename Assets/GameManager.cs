using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject TrebuchetPrefab;
    [SerializeField] Transform spawnPoint;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetTrebuchet();
        }
    }

    private void ResetTrebuchet()
    {
        GameObject currenTrebuchet = FindObjectOfType<TrebuchetController>().gameObject;
        Vector3 currentRotation = currenTrebuchet.transform.rotation.eulerAngles;

        Destroy(currenTrebuchet);

        GameObject newTrebuchet = Instantiate(TrebuchetPrefab, spawnPoint.position, Quaternion.Euler(currentRotation));
       
        newTrebuchet.transform.SetParent(null);
        newTrebuchet.transform.Rotate(Vector3.up, currentRotation.y);
    }
}
