using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 movement;
    private Vector2 mousePosition;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get GameObjects RigidBody2D with tagename Soldier 
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //Get GameObjects Camera with tagname MainCamera
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input for strafing
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Get mouse position and convert from pixel position to world position 
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

/*
        Debug.Log("X=" + movement.x);
        Debug.Log("Y=" + movement.y);
        Debug.Log("Movment=" + movement);
*/
    }

    private void FixedUpdate()
    {
        //Keeps strafe speed consistent through all planes, without normalize strafing is faster diaganoly 
        movement.Normalize();

        //Strafe movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        //Mouse movement
        Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f;
    }
}
