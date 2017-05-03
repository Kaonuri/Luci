using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
    public Vector3 alpha;
    public Vector3 rot;
    public Transform pivot;
    public float speed;
    public float smooth;

    public SphericalCoordinate sphericalCoordinate;

    private Vector3 target;
    private bool keyDown = false;
    private float wheel;

    private void Awake()
    {
        sphericalCoordinate = new SphericalCoordinate(transform.position);
        wheel = 3.5f;
    }

    private void Update()
    {
        sphericalCoordinate.Rotate(Input.GetAxis("Mouse X"), 0.0f, Input.GetAxis("Mouse ScrollWheel"), speed * Time.deltaTime);
        sphericalCoordinate.Rotate(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"), speed * Time.deltaTime);

        transform.position = Vector3.Slerp(transform.position, sphericalCoordinate.ToCartesian + (pivot.position + alpha), Time.deltaTime * smooth);
        target = Vector3.Slerp(target, pivot.position + alpha, Time.deltaTime*smooth);  
        transform.LookAt(target);
        Quaternion newRot = Quaternion.Euler(transform.rotation.eulerAngles + rot);
        transform.rotation = newRot;
    }
}
