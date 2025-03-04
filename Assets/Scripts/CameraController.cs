using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float sensitivity = 2f;
    public float distanceFromTarget = 5f;
    private float yaw, pitch;

    //public Transform target;
    //Vector3 distance;
    //public Vector2 turn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //distance = target.position - transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 60f);
        //turn.x += Input.GetAxis("Mouse X");
        //turn.y += Input.GetAxis("Mouse Y");
        //transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        //transform.LookAt(target);
    }
    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distanceFromTarget);
        transform.position = position;
        transform.LookAt(target.position);
    }

    //private void FixedUpdate()
    //{
    //    transform.position = target.position - distance;
    //}
}
