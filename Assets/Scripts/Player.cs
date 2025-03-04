using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    //float xInput;
    //float zInput;
    public Transform cameraTransform;
    public float moveSpeed;
    private Vector3 moveDirection;
    int coinsCollected;
    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        moveDirection = (forward * zInput + right * xInput).normalized;

        if (transform.position.y <= -3f)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);

        if (moveDirection.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        //float xVelocity = xInput * moveSpeed;
        //float zVelocity = zInput * moveSpeed;

        //rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y,  zVelocity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coinsCollected++;
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Stage")
        {
            SceneManager.LoadScene(0);
        }

    }
}
