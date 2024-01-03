using UnityEngine;
using UnityEngine.UI;

public class HealthPlayerController : MonoBehaviour
{
    //public int numOfHearts = 3;

    public Image[] hearts;

    public int heartCount = 3;

    private bool isChangeHeart = false;

    public void minusHeart()
    {
        heartCount--;
        isChangeHeart = true;
    }

    void Update()
    {
        if (isChangeHeart) {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < heartCount)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
            isChangeHeart = false;
        }
    }
    public void AddHeart()
    {
        if (heartCount == 3)
        {
            return;
        }
        else if (heartCount == 2)
        {
            heartCount++;
            hearts[2].enabled = true;
        }
        else if (heartCount == 1)
        {
            heartCount++;
            hearts[1].enabled = true;
        }
    }
}
