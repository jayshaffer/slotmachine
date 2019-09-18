using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float playDelay;
    public float lastPlay;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public bool CanPlay(){
        return lastPlay + playDelay < Time.time;
    }

    void Update()
    {
        float horiziontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        _rb.velocity = new Vector3(horiziontal, vertical, 0);
    }
}
