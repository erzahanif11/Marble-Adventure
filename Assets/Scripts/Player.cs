using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    float xInput;
    float zInput;
    public float moveSpeed;
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
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        if (transform.position.y <= -3f)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void FixedUpdate()
    {
        float xVelocity = xInput * moveSpeed;
        float zVelocity = zInput * moveSpeed;

        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y,  zVelocity);
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
