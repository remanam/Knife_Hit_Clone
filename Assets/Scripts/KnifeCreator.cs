using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCreator : MonoBehaviour
{
    [SerializeField] private Vector2 throwForce;

    private bool isActive = true;

    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true && isActive == true) {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            // TODO. Decrement number of aviable knifes
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive == false)
            return;

        isActive = false;

        if (collision.gameObject.tag == "Log") {
            Debug.Log("Knife Collided with Log");
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.8f);
        }
        else if (collision.collider.tag == "Knife") {
            rb.velocity = new Vector2(rb.velocity.x, -2);
        }
    }
}
