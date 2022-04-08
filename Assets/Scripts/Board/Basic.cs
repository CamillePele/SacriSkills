using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Basic : MonoBehaviour
{
    [SerializeField] private Uniquematerial uniquematerial;
    private float leftOffset = -2f;
    private float rightOffset = 2f;
    private float topOffset = 2f;
    private float bottomOffset = -2f;

    private float offset = 1f;

    public Vector2 center;

    public bool leftCube = false;
    public bool rightCube = false;
    public bool topCube = false;
    public bool bottomCube = false;

    private void Start()
    {
        

        leftCube = Physics2D.OverlapCircleAll((Vector2)transform.position + (Vector2) center + new Vector2(leftOffset, 0), 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Basic>() != null && !x.CompareTag("Board")).ToList().Count > 0;

        rightCube = Physics2D.OverlapCircleAll((Vector2)transform.position + (Vector2) center + new Vector2(rightOffset, 0), 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Basic>() != null && !x.CompareTag("Board")).ToList().Count > 0;     
        
        topCube = Physics2D.OverlapCircleAll((Vector2)transform.position + (Vector2) center + new Vector2(0, topOffset), 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Basic>() != null && !x.CompareTag("Board")).ToList().Count > 0;
        
        
        bottomCube = Physics2D.OverlapCircleAll((Vector2)transform.position + (Vector2) center + new Vector2(0, bottomOffset), 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Basic>() != null && !x.CompareTag("Board")).ToList().Count > 0;

        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        uniquematerial._2dPos = pos;
        uniquematerial._minusX = leftCube;
        uniquematerial._minusY = bottomCube;
        uniquematerial._plusX = rightCube;
        uniquematerial._plusY = topCube;
        
        uniquematerial.Setup();
    }

/*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        
        Gizmos.DrawWireSphere( (Vector2)transform.position + (Vector2)center  + new Vector2(center.x + leftOffset, center.y), 0.2f);
        Gizmos.DrawWireSphere((Vector2)transform.position + (Vector2)center  + new Vector2(center.x + rightOffset, center.y), 0.2f);
        Gizmos.DrawWireSphere((Vector2)transform.position + (Vector2)center  + new Vector2(center.x, center.y + bottomOffset), 0.2f);
        Gizmos.DrawWireSphere((Vector2)transform.position + (Vector2)center  + new Vector2(center.x, center.y + topOffset), 0.2f);
    }
    */
}
