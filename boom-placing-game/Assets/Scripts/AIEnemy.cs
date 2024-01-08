using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private TypeMovement typeMovement;
    [SerializeField] private TypeStateEnemyAI typeStateEnemy;
    [SerializeField] private Transform pos1; // up , left
    [SerializeField] private Transform pos2; // down , right
    [SerializeField] private EnemyMoveController enemyMovementController;
    [SerializeField] private float speedPatrol;

    private bool isPos1;
    private bool isIdle;

    private void Start()
    {
        typeStateEnemy = TypeStateEnemyAI.PATROL;
        flip();
    }
    private void Update()
    {
        actionState();
    }
    private void actionState()
    {
        switch (typeStateEnemy)
        {
            case TypeStateEnemyAI.NONE:
                break;
            case TypeStateEnemyAI.PATROL:
                move();
                break;
            case TypeStateEnemyAI.IDLE:
                if (!isIdle)
                    idle();
                break;
            default:
                break;
        }
    }
    private void changeState(TypeStateEnemyAI typeEnemy)
    {
        switch (typeEnemy)
        {
            case TypeStateEnemyAI.NONE:
                break;
            case TypeStateEnemyAI.PATROL:
                typeStateEnemy = typeEnemy;
                break;
            case TypeStateEnemyAI.IDLE:
                typeStateEnemy = typeEnemy;
                break;
            default:
                break;
        }
    }
    private void idle()
    {
        isIdle = true;
        StartCoroutine(IE_delayNextMoveTarget());
    }
    private void move()
    {
        if (!isPos1)
        {
            transform.Translate(pos1.localPosition * speedPatrol * Time.deltaTime, Space.World);
            if (Vector2.Distance(transform.position, pos1.position) <= 0.5f)
            {
                isPos1 = true;
                changeState(TypeStateEnemyAI.IDLE);
                Debug.Log("da den 1");
                flip();
            }
        }
        else
        {
            transform.Translate(pos2.localPosition * speedPatrol * Time.deltaTime, Space.World);
            if (Vector2.Distance(transform.position, pos2.position) <= 0.5f)
            {
                isPos1 = false;
                changeState(TypeStateEnemyAI.IDLE);
                Debug.Log("da den 2");
                flip();
            }
        }
    }
    private void flip()
    {
        switch (typeMovement)
        {
            case TypeMovement.NONE:
                break;
            case TypeMovement.VERTICAL:
                if (isPos1)
                    enemyMovementController.SetUpAnimIdle(Vector2.down);
                else
                    enemyMovementController.SetUpAnimIdle(Vector2.up);
                break;
            case TypeMovement.HORIZONTAL:
                if (isPos1)
                    enemyMovementController.SetUpAnimIdle(Vector2.right);
                else
                    enemyMovementController.SetUpAnimIdle(Vector2.left);
                break;
            default:
                break;
        }
    }
    IEnumerator IE_delayNextMoveTarget()
    {
        yield return new WaitForSeconds(1f);
        changeState(TypeStateEnemyAI.PATROL);
     //   isPos1 = !isPos1;
        isIdle = false;
    }
}
public enum TypeStateEnemyAI
{
    NONE = -1,
    PATROL,
    IDLE
}
public enum TypeMovement
{
    NONE = -1,
    VERTICAL,
    HORIZONTAL
}
