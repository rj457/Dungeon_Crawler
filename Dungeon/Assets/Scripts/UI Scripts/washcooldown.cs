using UnityEngine.UI; 
using UnityEngine;

public class washcooldown : MonoBehaviour
{
    public bool iswashcooldown;

    void Start()    
    {
        iswashcooldown = false;
        gameObject.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (iswashcooldown)
        {
            gameObject.GetComponent<Image>().fillAmount -= 1 / 2f * Time.deltaTime;
            if (gameObject.GetComponent<Image>().fillAmount <= 0)
            {
                iswashcooldown = false;
                gameObject.GetComponent<Image>().fillAmount = 0;
            }
        }
        else
        {
            return;
        }
    }
}
