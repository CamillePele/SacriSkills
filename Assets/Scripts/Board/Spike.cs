using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform leftPosition;
    public Transform rightPosition;

    public bool leftSpike = false;
    public bool rightSpike = false;

    public SpriteRenderer Middle;
    public SpriteRenderer Left;
    public SpriteRenderer Right;
    public SpriteRenderer Alone;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("spiek");
            Player player = (Player) other.GetComponent<Player>();
            player.Kill();
        }
    }

    private void Start()
    {
        leftSpike = Physics2D.OverlapCircleAll((Vector2)leftPosition.position, 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Spike>() != null && !x.CompareTag("Board")).ToList().Count > 0;

        rightSpike = Physics2D.OverlapCircleAll((Vector2)rightPosition.position, 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Spike>() != null && !x.CompareTag("Board")).ToList().Count > 0;

        if (leftSpike && rightSpike) Alone.enabled = true;
        else if (leftSpike) Left.enabled = true;
        else if (rightSpike) Right.enabled = true;
        else Middle.enabled = true;
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere( (Vector2)leftPosition.position, 0.2f);
        Gizmos.DrawWireSphere((Vector2)rightPosition.position, 0.2f);
    }
    
}
