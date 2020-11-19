using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        rb.AddForce(lookDirection * (speed * Time.deltaTime));

        if (transform.position.y < -10) 
            Destroy(gameObject);
    }
}
