using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerMinigamePlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = Vector3.right * moveSpeed * Input.GetAxisRaw("Horizontal");   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShowerMinigameManager manager = (ShowerMinigameManager)FindFirstObjectByType(typeof(ShowerMinigameManager));
        if (manager)
        {
            manager.CollectWater();
        }
        Destroy(collision.gameObject);
    }
}
