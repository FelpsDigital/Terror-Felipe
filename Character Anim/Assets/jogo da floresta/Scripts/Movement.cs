using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 boxAreaEsquerda;
    [SerializeField] Vector3 boxAreaDireita;
    [SerializeField] Vector3 boxAreaCostas;
    [SerializeField] Vector3 boxAreaFrente;
    public Color gizmoColor = Color.red;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] Transform playAttackPointDireito;
    [SerializeField] Transform playAttackPointEsquerdo;
    [SerializeField] Transform playAttackPointFrente;
    [SerializeField] Transform playAttackPointCostas;
    [SerializeField] float moveSpeed = 3;
    Rigidbody2D rig;
    Vector2 moveInput;
    private Animator animator;
    public float faceDirection = 1;
    public bool armado = true;
    Vector2 lastDirection = Vector2.down;
    public EnemyAnimations enemyAnimations;
    public SpriteRenderer spriteRenderer;
    [SerializeField] float invencTimer;
    public bool isInvencible = false;
    public Monster monster;
    [SerializeField] int vida = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyAnimations = FindAnyObjectByType<EnemyAnimations>();
        monster = GetComponent<Monster>();



    }

    // Update is called once per frame
    void Update()
    {
        Flip();



        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 5;

        }
        else
        {
            moveSpeed = 3;
        }
        if (moveInput != Vector2.zero)
        {
            lastDirection = moveInput;

        }
        Invencibility();
        if (enemyAnimations != null)
        {
            enemyAnimations.IsDamaged();
        }
        



    }
    private void FixedUpdate()
    {
        rig.linearVelocity = moveInput * moveSpeed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("Is Walking", true);
        if (context.canceled)
        {
            animator.SetBool("Is Walking", false);
            animator.SetFloat("Last Input X", moveInput.x);
            animator.SetFloat("Last Input Y", moveInput.y);
        }
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("Input X", moveInput.x);
        animator.SetFloat("Input Y", moveInput.y);
    }
    void Flip()
    {

        if (moveInput.x > 0.1f)
        {
            faceDirection = 1;
        }
        else if (moveInput.x < -0.1f)
        {
            faceDirection = -1;
        }

        transform.localScale = new Vector3(faceDirection, 1, 1);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma Branca") && armado == false)
        {
            Destroy(collision.gameObject);
            armado = true;
        }

    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.performed)

            return;

        if (armado == true)
        {
            animator.SetTrigger("Attack");
            animator.SetFloat("Last Input X", lastDirection.x);
            animator.SetFloat("Last Input Y", lastDirection.y);
        }

    }
    public void OnHit()
    {
        if (enemyAnimations == null)
        {
            return;
        }

    }
    public void Invencibility()
    {
        if (isInvencible == true)
        {
            invencTimer += Time.deltaTime;

        }
        if (invencTimer >= 1f)
        {
            isInvencible = false;
            invencTimer = 0;
            spriteRenderer.color = Color.white;

        }
    }

    public void PlayAttFrente()
    {
        Collider2D hit = Physics2D.OverlapBox(playAttackPointFrente.position, boxAreaFrente, 0f, enemyMask);

        if (hit != null)
        {
            vida = vida - 1;
            enemyAnimations.spriteRenderer.color = Color.red;
            enemyAnimations.damaged = true;
            enemyAnimations.IsDamaged();
            hit.GetComponent<KnockBackEffect>().StartKnockback(gameObject);
        }
        if (vida <= 0)
        {
            enemyAnimations.gameObject.SetActive(false);
        }
    }
    public void PlayAttDireito()
    {
        Collider2D hit = Physics2D.OverlapBox(playAttackPointDireito.position, boxAreaDireita, 0f, enemyMask);

        if (hit != null)
        {
            vida = vida - 1;
            enemyAnimations.spriteRenderer.color = Color.red;
            enemyAnimations.damaged = true;
            enemyAnimations.IsDamaged();
            hit.GetComponent<KnockBackEffect>().StartKnockback(gameObject);

        }
        if (vida <= 0)
        {
            enemyAnimations.gameObject.SetActive(false);
        }
    }
    public void PlayAttEsquerdo()
    {
        Collider2D hit = Physics2D.OverlapBox(playAttackPointEsquerdo.position, boxAreaEsquerda, 0f, enemyMask);

        if (hit != null)
        {
            vida = vida - 1;
            enemyAnimations.spriteRenderer.color = Color.red;
            enemyAnimations.damaged = true;
            enemyAnimations.IsDamaged();
            hit.GetComponent<KnockBackEffect>().StartKnockback(gameObject);
        }
        if (vida <= 0)
        {
            enemyAnimations.gameObject.SetActive(false);
        }
    }
    public void PlayAttCostas()
    {
        Collider2D hit = Physics2D.OverlapBox(playAttackPointCostas.position, boxAreaCostas, 0f, enemyMask);

        if (hit != null)
        {
            vida = vida - 1;
            enemyAnimations.spriteRenderer.color = Color.red;
            enemyAnimations.damaged = true;
            enemyAnimations.IsDamaged();
            hit.GetComponent<KnockBackEffect>().StartKnockback(gameObject);
        }
        if (vida <= 0)
        {
            enemyAnimations.gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(playAttackPointDireito.position, boxAreaDireita);
        Gizmos.DrawWireCube(playAttackPointFrente.position, boxAreaFrente);
        Gizmos.DrawWireCube(playAttackPointCostas.position, boxAreaCostas);
        Gizmos.DrawWireCube(playAttackPointEsquerdo.position, boxAreaEsquerda);
    }

}

