using UnityEngine.UI;
using UnityEngine;

public class wallcooldown : MonoBehaviour
{
    public bool iswallcooldown;

    void Start()
    {
        iswallcooldown = false;
        gameObject.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (iswallcooldown)
        {
            gameObject.GetComponent<Image>().fillAmount -= 1 / 2f * Time.deltaTime;
            if (gameObject.GetComponent<Image>().fillAmount <= 0)
            {
                iswallcooldown = false;
                gameObject.GetComponent<Image>().fillAmount = 0;
            }
        }
        else
        {
            return;
        }
    }
}