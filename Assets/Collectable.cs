using UnityEngine;
using UnityEngine.Tilemaps;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); //TODO destroy or hide?
    }
}
