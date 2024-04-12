using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    [SerializeField] private LayerMask jumpableGround;
    private Rigidbody2D rb2d;
    private BoxCollider2D coll2d;
    public Transform playerPosition;
    public bool chasing;
    public bool canJump;
    private Command enemyJumpCmd;
    [SerializeField] public float enemyRange;
    [SerializeField] public float enemyJumpForce = 2f;
    [SerializeField] public float jumpCooldown = 1f;
    [SerializeField] public float moveSpeed;
    public int patrolDestination;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<BoxCollider2D>();
        enemyJumpCmd = new JumpCommand(GetComponent<Rigidbody2D>(), enemyJumpForce);
    }

    public void Update()
    {

        if (chasing)
        {
            EnemyJump();
            if (transform.position.x > playerPosition.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerPosition.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerPosition.position) < enemyRange)
            {
                chasing = true;
            }
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }
            }
            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                }
            }
        }
    }

    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

    private void EnemyJump() 
    {
        if (OnGround()) 
        {
            enemyJumpCmd.Execute();
            canJump = false;
            StartCoroutine(JumpCooldown());
        }
    }

    private bool OnGround()
    {
        return Physics2D.BoxCast(coll2d.bounds.center, coll2d.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
