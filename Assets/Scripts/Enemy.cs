using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
            Die();
    }

    private void Die()
    {
        EnemyMovement enemyMovement = gameObject.GetComponent<EnemyMovement>();
        enemyMovement.Flip();

        gameObject.SetActive(false);
    }
}