using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    public GameObject bombPrefab;
    public KeyCode inputKey = KeyCode.LeftShift;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;
    private int bombsRemaining;

    [Header("Explosion")]
    public Explosion explosionPrefab;
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public const int explosionRadius = 2;

    //[Header("Destructible")]
    //public Tilemap destructibleTiles;
    //public Destructible destructiblePrefab;

    private void OnEnable()
    {
        bombsRemaining = bombAmount;
    }

    private void Update()
    {
        if (bombsRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            StartCoroutine(PlaceBomb());
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        //Debug.Log(position.x + " " + position.y);

        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        Debug.Log(position.x + " " + position.y);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombsRemaining--;

        yield return new WaitForSeconds(bombFuseTime);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);

        Destroy(bomb);
        bombsRemaining++;
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if (length <= 0)
        {
            return;
        }
        Debug.Log("Log 1: " + position + " " + direction);
        position += direction;
        Debug.Log("Log 2: " + position);

        //if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        //{
        //    ClearDestructible(position);
        //    return;
        //}

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        Debug.Log(length);
        Debug.Log(1 > 1 );
        explosion.SetActiveRenderer(length > 1 ? explosion.middle : explosion.end);
        //explosion.SetActiveRenderer(explosion.end);
        explosion.SetDirection(direction);
        explosion.DestroyAfter(explosionDuration);

        Explode(position, direction, length - 1);
    }

    //private void ClearDestructible(Vector2 position)
    //{
    //    Vector3Int cell = destructibleTiles.WorldToCell(position);
    //    TileBase tile = destructibleTiles.GetTile(cell);

    //    if (tile != null)
    //    {
    //        Instantiate(destructiblePrefab, position, Quaternion.identity);
    //        destructibleTiles.SetTile(cell, null);
    //    }
    //}

}
