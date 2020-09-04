using UnityEngine.UI;
using UnityEngine;

public class maskcooldown : MonoBehaviour
{
    public bool ismaskbooldown; 

    void Start()
    {
        ismaskbooldown = false;
        gameObject.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ismaskbooldown)
        {
            gameObject.GetComponent<Image>().fillAmount -= 1 / 2f * Time.deltaTime; 
            if (gameObject.GetComponent<Image>().fillAmount <= 0)
            {
                ismaskbooldown = false;
                gameObject.GetComponent<Image>().fillAmount = 0; 
            }
        }
        else
        {
            return; 
        }
    }
}
