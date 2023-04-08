using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    ForceMeter fm;
    HoleController hc;
    //Vector2 hitBall = new(0, 1);
    Vector3 dragStartPos;
    Vector3 dragReleasePos;
    Vector3 draggingPos;


    public float speed;
    public float maxDrag = 3f;
    private bool isHit;
    private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fm = GetComponent<ForceMeter>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isHit && rb.velocity.magnitude > 0.1)
        {
            isMoving = true;
        }
        else
        isMoving = false;

        if (!isMoving)
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

        Debug.Log(rb.velocity);
        //Debug.Log(rb.velocity);
        //Debug.Log(isHit);
        //Debug.Log(rb.velocity.magnitude);
        //Debug.Log(isMoving);
        //Debug.Log(isDown);
        //Debug.Log(isOut);
        //Debug.Log(rb.velocity);
    }


    //Add force to the ball according to the drag position
    public void DragStart() 
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragStartPos.z = 0;
    }
    public void Dragging()
    {
        draggingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draggingPos.z = 0;
        fm.RenderLine(draggingPos, dragStartPos);

    }
    public void DragRelease()
    {
        dragReleasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragReleasePos.z = 0;

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * speed;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
        isHit = true;
        fm.EndLine();
    }

}
