using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 300;
    [SerializeField] float moveSpeed = 20;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    bool hasSpedUp;
    bool hasSlowedDown;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Speed Up")
        {
            hasSlowedDown = false;
            hasSpedUp = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        hasSpedUp = false;
        hasSlowedDown = true;
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount;

        if (hasSpedUp)
        {
            moveAmount = Input.GetAxis("Vertical") * boostSpeed * Time.deltaTime;
        }
        else if (hasSlowedDown)
        {

            moveAmount = Input.GetAxis("Vertical") * slowSpeed * Time.deltaTime;
        }
        else
        {
            moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        }

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
