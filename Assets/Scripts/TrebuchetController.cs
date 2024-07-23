using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrebuchetController : MonoBehaviour
{
    [SerializeField] Rigidbody Wheight;
    [SerializeField] GameObject projectile;
    [SerializeField] float rotationSensitivity = 0.5f;
    Vector3 rotationChange;
    float _initialWheightMass;

    [HideInInspector] public CameraView CameraViewScript;
    [HideInInspector] public CameraFollow CameraFollowScript;
    private void Awake()
    {
        //setup scripts
        CameraFollowScript = FindObjectOfType<CameraFollow>();
        CameraViewScript = FindObjectOfType<CameraView>();
    }
    //INPUT IS TEMPORARY FOR DEBUGGING AND DEVELOPMENT AND NOT DESIGNED FOR MOBILE PLATFORMS YET
    private void OnInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Activate wheigh gravity
            Wheight.isKinematic = false;
            projectile.transform.SetParent(null);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Destroy the Hinge and the projectile launches
            HingeJoint hingeJoint;
            hingeJoint = projectile.GetComponent<HingeJoint>();

            Destroy(hingeJoint);

            CameraFollowScript.FindProjectile();
            CameraViewScript.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _initialWheightMass = Wheight.mass;
            Wheight.mass *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Wheight.mass = _initialWheightMass;
        }

        //Rotate Trebuchet
        if (Input.GetKey(KeyCode.A))
        {
            rotationChange += new Vector3(0, Input.GetAxis("Horizontal") * rotationSensitivity * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotationChange -= new Vector3(0, Input.GetAxis("Horizontal") * -rotationSensitivity * Time.deltaTime, 0);
        }

        transform.eulerAngles = rotationChange;
    }
    void Update()
    {
        OnInput();
    }
}
