using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public string areanTrasitionName;


    Rigidbody2D _rb;
    Animator _anim;
    private Vector3 _bottomLeft;
    private Vector3 _topRight;
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);



        DontDestroyOnLoad(gameObject);
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

        Controls();
        AnimationDirections();
        Bounds();


       
    }

    public void Controls()
    {
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
    }
    public void AnimationDirections()
    {
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
    public void Bounds()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeft.x, _topRight.x), Mathf.Clamp(
       transform.position.y, _bottomLeft.y, _topRight.y), transform.position.z);
    }
    public void SetBounds(Vector3 bottomLeft , Vector3 topRight)
    {
        _bottomLeft = bottomLeft + new Vector3(.5f,.5f,1);
        _topRight = topRight + new Vector3(-.5f, -.5f, -1);
    }
}
