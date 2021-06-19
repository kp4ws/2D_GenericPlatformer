using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float walkLimit = 5f;
    [SerializeField] private float amount = 1f;

    private float walkTimer = 0f;
    private float deathTime = 1f;
    private bool isDead;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDead)
            return;

        Move();

        walkTimer += Time.deltaTime;

        if(walkTimer > walkLimit)
        {
            walkTimer = 0;
            FlipSprite();
        }
    }

    private void Move()
    {
        Vector2 velocity = new Vector2(walkSpeed * transform.localScale.x * -1, rb.velocity.y);
        rb.velocity = velocity;
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
            return;

        if(collision.transform.position.y > transform.position.y + amount)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetTrigger("die");
        isDead = true;

        yield return new WaitForSeconds(deathTime);
        gameObject.SetActive(false);
    }

}
