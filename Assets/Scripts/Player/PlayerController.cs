using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;


    Rigidbody2D _rb;
    Animator _anim;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        _anim.SetFloat("moveX", _rb.velocity.x);
        _anim.SetFloat("moveY", _rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            _anim.enabled = true;
            _anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            _anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));

        }
        else
        {
            _anim.enabled = false;
        }
    }
}
