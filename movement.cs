using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D Rb;
    public LayerMask groundLayer;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLine = 2;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ground check
        onGround = Physics2D.Raycast(transform.position , Vector2.down, groundLine, groundLayer);

        //Inputs 
        bool space = Input.GetKey(KeyCode.Space);
        bool rightKey = Input.GetKey(KeyCode.RightArrow);
        bool leftKey = Input.GetKey(KeyCode.LeftArrow);

        if (rightKey){
            Debug.Log("Right Key Pressed");
            Rb.AddForce(Vector2.right, ForceMode2D.Impulse);
        }

        if (leftKey){
            Debug.Log("Left Key Pressed");
            Rb.AddForce(Vector2.left, ForceMode2D.Impulse);
        }

        if (space && onGround){
            Debug.Log("Space Key Pressed");
            Rb.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLine);
    }
}


