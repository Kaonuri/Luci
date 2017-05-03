using UnityEngine;
using System.Collections;

public class ThirdPersonCameraAir : MonoBehaviour
{
    public Vector3 alpha;
    public Vector3 rot;
    public Transform pivot;
    public float speed;
    public float smooth;

    private AirVRCameraRig cameraRig;

    public SphericalCoordinate sphericalCoordinate;

    private void Awake()
    {
        sphericalCoordinate = new SphericalCoordinate(transform.position);
        cameraRig = FindObjectOfType<AirVRCameraRig>();
    }

    private void Update()
    {
        sphericalCoordinate.Rotate(AirVRInput.GetAxis(cameraRig, AirVRInput.Touchpad.Axis.DragX), 0, AirVRInput.GetAxis(cameraRig, AirVRInput.Touchpad.Axis.DragY), speed * Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position, sphericalCoordinate.ToCartesian + (pivot.position + alpha), Time.deltaTime * smooth);
    }
}
