using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageWave : MonoBehaviour
{
    [SerializeField] Vector2 amplitude;
    [SerializeField] float frequency;

    Vector2 basePos;

    private void Awake()
    {
        basePos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = basePos + (Mathf.Sin(frequency * Time.time) * amplitude);
    }
}
