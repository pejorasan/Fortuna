using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    //Vector2 hitBall = new(0, 1);
    Vector3 dragStartPos;
    //Touch touch;
    

    public float speed;
    public float maxDrag = 5f;
    private bool isHit;
    private bool isOut;
    private bool isDown;



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
            //Check mouse input
            if (Input.GetMouseButtonDown(0))
            {
                DragStart();
            }
            if (Input.GetMouseButton(0))
            {
                Dragging();
            }
            if (Input.GetMouseButtonUp(0))
            {
                DragRelease();
                isHit = true;
            }              
        }
  

        //Debug.Log(isHit);
        Debug.Log(isDown);
        //Debug.Log(rb.velocity);
    }

    //Add force to the ball according to the drag position
    private void DragStart() 
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragStartPos.z = 0;
    }
    private void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draggingPos.z = 0;
    }
    private void DragRelease()
    {
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragReleasePos.z = 0;

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * speed;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ShotCheck") 
        {
            isOut = true;
        }
        if (collision.gameObject.name == "DownCheck")
        {
            isDown = true;
        }
    }


}
