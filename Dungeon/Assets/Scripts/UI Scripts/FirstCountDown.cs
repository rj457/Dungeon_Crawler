using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class FirstCountDown : MonoBehaviour
{
    private float firstwait; 

    // Start is called before the first frame update
    void Start()
    {
        firstwait = 3f; 
    }

    // Update is called once per frame
    void Update()
    {
        firstwait -= 1 * Time.deltaTime;
        gameObject.GetComponent<TextMeshProUGUI>().text = firstwait.ToString("0");
        if (firstwait <= 0)
        {
            gameObject.SetActive(false); 
        }
    }
}
