using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            Die(collision);
        }
    }

    private void Die(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        enemy.Flip();
        enemy.gameObject.SetActive(false);
    }
}