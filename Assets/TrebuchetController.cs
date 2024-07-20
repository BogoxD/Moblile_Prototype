using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrebuchetController : MonoBehaviour
{
    [SerializeField] Rigidbody wheight;
    [SerializeField] GameObject projectile;
    [SerializeField] float rotationSensitivity = 0.5f;
    Vector3 rotationChange;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            wheight.isKinematic = false;
            projectile.transform.SetParent(null);
                
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            HingeJoint hingeJoint;

            hingeJoint = projectile.GetComponent<HingeJoint>();

            Destroy(hingeJoint);
        }


        if(Input.GetKey(KeyCode.A))
        {
            rotationChange += new Vector3(0, Input.GetAxis("Horizontal") * rotationSensitivity * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotationChange -= new Vector3(0, Input.GetAxis("Horizontal") * -rotationSensitivity * Time.deltaTime, 0);
        }

        transform.eulerAngles = rotationChange;

    }
}
