using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Vector3 distance;
    public Vector2 turn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distance = target.position - transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        //transform.LookAt(target);
    }

    private void FixedUpdate()
    {
        transform.position = target.position - distance;
    }
}
