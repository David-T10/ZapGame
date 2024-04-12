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
    public EnemyState currentState;
    public bool canJump;
    public float enemyRange;
    public float enemyJumpForce = 2f;
    public float jumpCooldown = 1f;
    public float moveSpeed;
    public int patrolDestination;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<BoxCollider2D>();
        currentState = new PatrollingState(this);
    }

    public void Update()
    {
        currentState.UpdateState();
    }

    public void TransitionToState(EnemyState newState)
    {
        currentState = newState;
    }

    public void Move(Vector2 direction)
    {
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }

    public void FlipSprite(float directionX)
    {
        if (directionX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (directionX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public bool PlayerInRange()
    {
        return Vector2.Distance(transform.position, playerPosition.position) < enemyRange;
    }

    public void Jump()
    {
        if (OnGround())
        {
            rb2d.AddForce(Vector2.up * enemyJumpForce, ForceMode2D.Impulse);
        }
    }

    public IEnumerator StartJumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }

    public bool OnGround()
    {
        return Physics2D.BoxCast(coll2d.bounds.center, coll2d.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}