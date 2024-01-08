using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    private Vector2 direction = Vector2.down;

    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;
  
    public void SetUpAnimIdle(Vector2 direction)
    {
        this.direction = direction;
        if (direction == Vector2.down)
        {
            SetDirection(Vector2.down, spriteRendererDown);
        }
        else if (direction == Vector2.up)
        {
            SetDirection(Vector2.down, spriteRendererUp);
        }
        else if (direction == Vector2.right)
        {
            SetDirection(Vector2.down, spriteRendererRight);
        }
        else if (direction == Vector2.left)
        {
            SetDirection(Vector2.down, spriteRendererLeft);
        }
    }
    public void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }
}
