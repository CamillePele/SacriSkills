using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHitbox : MonoBehaviour
{
    public Board board;

    private void OnTriggerEnter2D(Collider2D other)
    {
        board.OnChildTriggerEnter2D(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        board.OnChildTriggerExit2D(other);
    }
}
