using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    public readonly int Run = Animator.StringToHash(nameof(Run));

    private Animator _animator;
    private Vector3 _direction;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.Play(Run);
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;

        Flip();
    }

    public void Flip()
    {
        if (_direction.x < 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= 1;
            transform.localScale = localScale;
        }
        else if (_direction.x > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}