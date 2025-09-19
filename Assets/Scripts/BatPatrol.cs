using UnityEngine;

public class BatPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.05f;
    [SerializeField] float turnSpeed = 0.05f;
    [SerializeField] float turnTimer = 3f;
    bool canTurn = true;
    float timer = 0;
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed);
        transform.Rotate(0, turnSpeed, 0);
        if (Input.GetKey("r") && canTurn)
        {
            DirectionChange();
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            canTurn = true;
        }
    }
    void DirectionChange()
    {
        turnSpeed *= -1;
        transform.Rotate(0, 180, 0);
        canTurn = false;
        timer = turnTimer;
    }
}
