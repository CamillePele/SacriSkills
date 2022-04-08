using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 1;
    public Transform offset;
    public LayerMask environment;
    
    public void Init(Vector3 _dir)
    {
        dir = _dir.normalized;
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        //Debug.Log(transform.position);

        RaycastHit2D hit = Physics2D.Raycast(offset.position, transform.right * -1);
        Debug.DrawRay(transform.position + offset.position, transform.right * -1);
        if (hit.transform == null) return;
        if (hit.transform.gameObject.layer == 3 && hit.distance < 0.01f)
        {
            Destroy();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy();
        Debug.Log(other.transform.name);
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("laser");
            Player player = (Player) other.GetComponent<Player>();
            player.Kill();
        }
    }

    void Destroy()
    {
        transform.gameObject.SetActive(false);
    }
    

    
}
