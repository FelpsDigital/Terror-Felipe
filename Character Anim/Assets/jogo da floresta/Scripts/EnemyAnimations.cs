
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
public class EnemyAnimations : MonoBehaviour
{
    public bool damaged;
    private Animator animator;
    [SerializeField] Transform player;
    public SpriteRenderer spriteRenderer;
    [SerializeField] LayerMask playerMask;
    [SerializeField] Transform attackPointLado;
    [SerializeField] float radius;
    public Color gizmoColor = Color.red;
    [SerializeField] Transform attackPointFrente;
    [SerializeField] Transform attackPointCostas;
    [SerializeField] float radiusFrente;
    [SerializeField] float radiusCostas;
    [SerializeField] Transform attackPointLadoDireito;
    [SerializeField] float radiusLadoDireito;
    private Movement movement;
    private float colorTimer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = FindAnyObjectByType<Movement>();
        

    }


    // Update is called once per frame
    void Update()
    {
        movement.Invencibility();
        IsDamaged();

        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        animator.SetFloat("DirX", direction.x);
        animator.SetFloat("DirY", direction.y);
        animator.SetBool("IsMoving", direction.magnitude > 0f);

        if (direction.x < 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x > 0f)
        {
            spriteRenderer.flipX = true;
        }

    }

    public void DanoLado()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPointLado.position, radius, playerMask);


        if (hit != null)
        {
            movement.isInvencible = true;
            movement.spriteRenderer.color = Color.red;
            movement.Invencibility();

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(attackPointLado.position, radius);
        Gizmos.DrawWireSphere(attackPointFrente.position, radiusFrente);
        Gizmos.DrawWireSphere(attackPointCostas.position, radiusCostas);
        Gizmos.DrawWireSphere(attackPointLadoDireito.position, radiusLadoDireito);
    }
    public void DanoFrente()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPointFrente.position, radiusFrente, playerMask);

        if (hit != null)
        {

            movement.isInvencible = true;
            movement.spriteRenderer.color = Color.red;
            movement.Invencibility();
        }
    }
    public void DanoCostas()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPointCostas.position, radiusCostas, playerMask);

        if (hit != null)
        {

            movement.isInvencible = true;
            movement.spriteRenderer.color = Color.red;
            movement.Invencibility();
        }
    }
    public void DanoLadoDireito()
    {


        Collider2D hit = Physics2D.OverlapCircle(attackPointLadoDireito.position, radiusLadoDireito, playerMask);

        if (hit != null)
        {
            movement.isInvencible = true;
            movement.spriteRenderer.color = Color.red;
            movement.Invencibility();

        }

    }

    public void IsDamaged()
    {
        if (damaged == true)
        {
            colorTimer += Time.deltaTime;
        }
        if (colorTimer >= 1)
        {
            spriteRenderer.color = Color.white;
            damaged = false;
            colorTimer = 0;
        }
    }
}
