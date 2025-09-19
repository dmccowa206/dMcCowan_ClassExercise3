using UnityEngine;

public class BatPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8.24668f;
    [SerializeField] float turnSpeed = 90f;
    [SerializeField] float turnTimer = 1f;
    bool canTurn = true;
    float timer = 0;
    void Update()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
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
