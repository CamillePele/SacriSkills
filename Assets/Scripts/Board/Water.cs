
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("water");
            Player player = (Player) other.GetComponent<Player>();
            player.Kill();
        }
    }
}
