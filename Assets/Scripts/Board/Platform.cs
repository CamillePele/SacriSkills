using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Platform : MonoBehaviour
{
    public BoxCollider2D BoxCollider;

    public Transform leftPosition;
    public Transform rightPosition;

    public bool leftPlatform = false;
    public bool rightPlatform = false;
    
    public SpriteRenderer Middle;
    public SpriteRenderer Left;
    public SpriteRenderer Right;
    public SpriteRenderer Alone;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        BoxCollider.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        BoxCollider.enabled = true;
    }
    
    private void Start()
    {
        leftPlatform = Physics2D.OverlapCircleAll((Vector2)leftPosition.position, 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Platform>() != null && !x.CompareTag("Board")).ToList().Count > 0;

        rightPlatform = Physics2D.OverlapCircleAll((Vector2)rightPosition.position, 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Platform>() != null && !x.CompareTag("Board")).ToList().Count > 0;

        if (leftPlatform && rightPlatform) Alone.enabled = true;
        else if (leftPlatform) Left.enabled = true;
        else if (rightPlatform) Right.enabled = true;
        else Middle.enabled = true;
        
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere( (Vector2)leftPosition.position, 0.2f);
        Gizmos.DrawWireSphere((Vector2)rightPosition.position, 0.2f);
    }
}
