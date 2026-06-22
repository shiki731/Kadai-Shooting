using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSystem : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody2D rb;
    InputAction moveAction;

    float axisX = 0.0f;
    float axisY = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerInput input = GetComponent<PlayerInput>();
        moveAction = input.currentActionMap.FindAction("Move");

    }

    // Update is called once per frame
    void Update()
    {
        if (axisY == 0)
        {
            axisX = moveAction.ReadValue<Vector2>().x;
            if (moveAction.ReadValue<Vector2>().y != 0)
            {
                axisX = 0;
                axisY = moveAction.ReadValue<Vector2>().y;
            }
        }
        if (axisX == 0)
        {
            axisY = moveAction.ReadValue<Vector2>().y;
            if (moveAction.ReadValue<Vector2>().x != 0)
            {
                axisY = 0;
                axisX = moveAction.ReadValue<Vector2>().x;
            }
        }


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(axisX * speed, axisY * speed);
    }
}
