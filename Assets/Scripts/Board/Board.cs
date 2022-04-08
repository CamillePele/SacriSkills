using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Board : MonoBehaviour
{
    public GameObject virtualCamera;
    public List<Transform> spawnPoints;
    public UnityEvent startBoardEvent;
    public UnityEvent endBoardEvent;
    public UnityEvent endRound;

    public void OnChildTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) ;
        {
            Player player = (Player) other.GetComponent<Player>();

            virtualCamera.SetActive(true);
            SetSpawnPoint(player);
            startBoardEvent.Invoke();
        }
    }

    public void OnChildTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) ;
        {
            Player player = (Player) other.GetComponent<Player>();

            virtualCamera.SetActive(false);
            endBoardEvent.Invoke();
            endRound.Invoke();
        }
    }

    public void SetSpawnPoint(Player player)
    {
        player.spawnPoint = spawnPoints.AsEnumerable()
                                       .OrderBy(x => Vector2.Distance(player.transform.position, x.position))
                                       .ToList()[0].position;
    }
}
