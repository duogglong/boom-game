using System.Collections;
using UnityEngine;

public class BombPlayerController : MonoBehaviour
{
    //Player General
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;

    // Player settings
    //private int heartCount;
    private bool isEvening = false;

    private void Awake()
    {
        Debug.Log("Instance PlayerBombController is creating...");
    }

    private int getCurrentHeart()
    {
        return GetComponent<HealthPlayerController>().heartCount;
    }

    private void minusHeart()
    {
        GetComponent<HealthPlayerController>().minusHeart();
    }

    private void OnTriggerEnter2D(Collider2D other)
     {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            SubtractBlood();
        }
     }

    private void SubtractBlood()
    {
        if (isEvening)
        {
            return;
        }
        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;

        // lock heart, movement
        isEvening = true;
        OnEveningMovementController(true);

        StartCoroutine(ResetIsEveningChange());

        minusHeart();
        Debug.Log("Blood: " + getCurrentHeart());
        Debug.Log("Blood: " + (getCurrentHeart() <= 0));
        if (getCurrentHeart() <= 0)
        {
            Invoke(nameof(OnPlayerDeath), 1.25f);
        }
        else
        {
            Invoke(nameof(AfterSubtractBlood), 1f);
        }
    }

    private void AfterSubtractBlood()
    {
        spriteRendererDown.enabled = true;
        spriteRendererDeath.enabled = false;
    }

    private void OnPlayerDeath()
    {
        gameObject.SetActive(false);
        GetComponent<BombController>().enabled = false;
    }

    IEnumerator ResetIsEveningChange()
    {
        yield return new WaitForSeconds(1.0f);
        OnEveningMovementController(false);
        isEvening = false;
    }

    private void OnEveningMovementController(bool isEvening)
    {
        MovementPlayerController movementScript = GetComponent<MovementPlayerController>();
        movementScript.isEvening = isEvening;
    }
}
