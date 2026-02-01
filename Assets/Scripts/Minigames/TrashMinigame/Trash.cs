using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] float forceMultplier;
    Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseDelta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rb2d.velocity = mouseDelta * forceMultplier;       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TrashMinigame manager = (TrashMinigame)FindFirstObjectByType(typeof(TrashMinigame));
        if (manager)
        {
            manager.DropoffTrash();
        }
        Destroy(gameObject);
    }
}
