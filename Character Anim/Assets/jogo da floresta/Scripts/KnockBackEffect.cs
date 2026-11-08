using UnityEngine;

public class KnockBackEffect : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float strength = 16f;
    [SerializeField] float duration = 1;

    float timer;


    public bool knockback;

    public void StartKnockback(GameObject sender)
    {
        timer = 0;
        knockback = true;
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * strength, ForceMode2D.Impulse);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (knockback && timer >= duration)
        {
            rb.linearVelocity = Vector2.zero;
            knockback = false;
        }
    }
}







