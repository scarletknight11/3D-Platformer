using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float jumpForce = 5;
    public bool isOnGround = true;
    public TMP_Text score;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;
    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
           Destroy(other.gameObject);
           num++; 
           score.text =  num.ToString();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
