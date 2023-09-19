using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;                   

    public float forwardForce = 1000f;      
    public float sidewaysForce = 500f;      
    
    void FixedUpdate ()                  
    {
        
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            Command moveRight = new TurnRight(rb, sidewaysForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveRight);
            invoker.ExecuteCommandWithEnqueue(moveRight);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            Command moveLeft = new TurnLeft(rb, sidewaysForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveLeft);
            invoker.ExecuteCommandWithEnqueue(moveLeft);
        }

        if (rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}