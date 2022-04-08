using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 spawnPoint;
    public Transform visual;
    public bool dead;
    
    public void Kill()
    {
        Debug.Log("Mort");
        visual.gameObject.SetActive(false);

        dead = true;
        
        StartCoroutine(WaitToSpawn(1f));
    }

    public void Spawn()
    {
        transform.position = spawnPoint;
        visual.gameObject.SetActive(true);
        dead = false;
    }
    
    public IEnumerator WaitToSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        Spawn();
    }

    public void BlockInputs()
    {
        dead = true;
    }
}
