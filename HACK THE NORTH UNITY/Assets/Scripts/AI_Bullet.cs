using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Bullet : MonoBehaviour
{
    private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}