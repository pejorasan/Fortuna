using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Vector2 hitBall = new(0, 1);
    private bool isHit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                HitBall();
                rb.AddForce(hitBall * speed, ForceMode2D.Impulse);
                isHit = true;
            }
        }      
    }

    private void HitBall()
    {
        Vector2 hitBall = new(0, 1);
        rb.AddForce(hitBall * speed, ForceMode2D.Impulse);
    }
}
