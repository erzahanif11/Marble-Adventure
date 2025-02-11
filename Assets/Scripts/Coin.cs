using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, rotateSpeed, 0);
        //transform.Rotate(Vector3.up*100*Time.deltaTime,Space.Self);
    }

}
