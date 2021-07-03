using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    Transform target;
    public Tilemap theMap;

    private Vector3 _bottomLeft;
    private Vector3 _topRight;
    private float _halfHeight;
    private float _halfwidth;
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        _halfHeight = Camera.main.orthographicSize;
        _halfwidth = _halfHeight * Camera.main.aspect;
        _bottomLeft = theMap.localBounds.min + new Vector3(_halfwidth , _halfHeight , 0);
        _topRight = theMap.localBounds.max + new Vector3(-_halfwidth, -_halfHeight, 0);

        PlayerController.instance.SetBounds(theMap.localBounds.min , theMap.localBounds.max);
    }

  
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _bottomLeft.x, _topRight.x), Mathf.Clamp(
        transform.position.y, _bottomLeft.y, _topRight.y), transform.position.z);
    }
}
