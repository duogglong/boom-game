using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimatedSpriteRenderer start;
    public AnimatedSpriteRenderer middle;
    public AnimatedSpriteRenderer end;

    public void SetActiveRenderer(AnimatedSpriteRenderer renderer)
    {
        start.enabled = renderer == start;
        middle.enabled = renderer == middle;
        end.enabled = renderer == end;
    }

    public void SetDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void DestroyAfter(float seconds)
    {
        Destroy(gameObject, seconds);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BrickController brick = collision.GetComponent<BrickController>();
        Player player = collision.GetComponent<Player>();
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (brick != null)
        {
            brick.changeStateBrick(TypeBrick.BREAKING);
        }
        if (player != null)
        {
            player.OnDead();
        }
        if (enemy != null)
        {
            enemy.Ondead();
        }
    }
}
