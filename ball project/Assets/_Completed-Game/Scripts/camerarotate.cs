using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarotate : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 _cameraOffSet;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    public bool lookAtPlayer = false;

    public bool rotateAroundPlayer = true;

    public float rotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _cameraOffSet = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rotateAroundPlayer)
        {
            Quaternion camTurnAngle =
            Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            _cameraOffSet = camTurnAngle * _cameraOffSet;
        }

        Vector3 newpos = playerTransform.position + _cameraOffSet;

        transform.position = Vector3.Slerp(transform.position, newpos, smoothFactor);

        if (lookAtPlayer || rotateAroundPlayer)
        {
            transform.LookAt(playerTransform);
        }
    }
}
