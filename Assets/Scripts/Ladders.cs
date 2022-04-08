using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{

    public bool isInRange;

    private Movement playerMovement;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    void Update()
    {
        if(isInRange && Mathf.Abs(Input.GetAxis("Vertical")) != 0)
        {
            playerMovement.isClimbing = true;
        } else if (!isInRange || playerMovement.collision.onGround)
            playerMovement.isClimbing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
