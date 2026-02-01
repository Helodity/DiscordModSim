using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerMinigameWaterDroplet : MonoBehaviour
{
    [SerializeField] float Attraction;
    Rigidbody2D rb2d;
    Transform player;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<ShowerMinigamePlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity += (Vector2)(player.position - transform.position).normalized * Attraction * (Gamestate.GetScore(Stats.Smelliness) * 2 - 1) * Time.deltaTime;
    }
}
