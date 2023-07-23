using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveDir;
    [SerializeField] float moveSpeedX = 7f;
    [SerializeField] float moveSpeedY = 5f;
    [SerializeField] float posX = 8.5f;
    [SerializeField] float posY = 4.5f;
    [SerializeField] float negX = -8.5f;
    [SerializeField] float negY = -4.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        float objXPos = transform.position.x;
        float objYPos = transform.position.y;
        moveDir = new Vector2(xAxis, yAxis);
        if (objXPos > posX)
        {
            transform.position = new Vector2(posX, objYPos);
        }
        if (objXPos < negX)
        {
            transform.position = new Vector2(negX, objYPos);
        }
        if (transform.position.y > posY)
        {
            transform.position = new Vector2(objXPos, posY);
        }
        if (transform.position.y < negY)
        {
            transform.position = new Vector2(objXPos, negY);
        }
    }
    private void FixedUpdate()
    {
        //new Vector2(moveDir.x * 15, moveDir.y * 15)
        rb.velocity = new Vector2(moveDir.x * moveSpeedX, moveDir.y * moveSpeedY);
        transform.rotation = Quaternion.Euler(new Vector3(0,0,-moveDir.x * 15));
        //Debug.Log(moveDir);
        //transform.Translate(moveDir * moveSpeed);
    }
}
