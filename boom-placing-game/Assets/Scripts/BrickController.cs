using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Start()
    {
        changeStateBrick(TypeBrick.IDLE);
    }
    public void changeStateBrick(TypeBrick typeBrick)
    {
        switch (typeBrick)
        {
            case TypeBrick.NONE:
                break;
            case TypeBrick.IDLE:
                animator.SetTrigger("Idle");
                break;
            case TypeBrick.BREAKING:
                animator.SetTrigger("Breaking");
                StartCoroutine(IE_delayDestroyBrick());
                break;
            default:
                break;
        }
    }
    IEnumerator IE_delayDestroyBrick()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
public enum TypeBrick
{
    NONE = -1,
    IDLE,
    BREAKING
}
