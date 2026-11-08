using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private float horizontal;
    [SerializeField] float speed = 8;
    private bool isFacingRight = true;

    private void Update()
    {

        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed,rb.linearVelocity.y);

        if (!isFacingRight && horizontal>0)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0)
        {
            Flip();
        } 
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        horizontal = ctx.ReadValue<Vector2>().x;
        
    }
    
}
