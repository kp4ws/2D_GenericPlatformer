using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Destroy(gameObject); //TODO destroy or hide?
    }
}
