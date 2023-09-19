using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private Vector3 _direction;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.Play("Run");
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;

        if (_direction.x >= 0)
            Flip();
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
