
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] float jumpForce = 300f;
    float moveVal, turnVal, kbX, kbY, kbZ;
    bool canJump = false;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bat"))
        {
            kbX = Random.Range(-2, 2) * 100;
            kbY = Random.Range(-2, 2) * 100;
            kbZ = Random.Range(-2, 2) * 100;
            rb.AddForce(kbX, kbY, kbZ);
        }
    }
    void Movement()
    {
        moveVal = Input.GetAxis("Vertical");
        turnVal = Input.GetAxis("Horizontal");
        transform.Translate(0, 0, moveVal * moveSpeed * Time.deltaTime);
        transform.Rotate(0, turnVal * turnSpeed, 0 * Time.deltaTime);
    }
    void Jump()
    {
        if (canJump)
        {
            rb.AddForce(0, jumpForce, 0);
        }
    }
}
