using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private Transform _head;
    [SerializeField] private float _rangeSpread;
    [SerializeField] private float _distance;
    [SerializeField] private ContactFilter2D _filter;

    private List<RaycastHit2D> _hitsList = new List<RaycastHit2D>(16);
    private RaycastHit2D[] _hits = new RaycastHit2D[12];
    private bool isFacingRight = false;

    private void Start()
    {
        _distance += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        int hitsCount = Physics2D.Raycast(_head.position, Vector3.left, _filter, _hits, _distance);
        Debug.DrawRay(_head.position, Vector3.left, Color.red);

        for (int i = 0; i < hitsCount; i++)
        {
            _hitsList.Add(_hits[i]);
        }

        if (hitsCount > 0)
        {
            NeedTransit = true;
        }

        _hitsList.Clear();
    }

    private void FixedUpdate()
    {
        if (isFacingRight == false)
        {
            Flip();
        }
        else if (isFacingRight == true)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        if (transform.position.x < Target.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (transform.position.x > Target.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}