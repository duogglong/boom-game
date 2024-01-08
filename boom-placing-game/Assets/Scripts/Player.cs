using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int count;
    private Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    public void OnDead()
    {
        count++;
        transform.position = startPos;
        if (count == 3)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PosWin"))
        {
            Debug.Log("WIN");
        }
    }
}
