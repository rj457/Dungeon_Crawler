using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;


public class countDownTimer : MonoBehaviour
{
    public float currentTime;
    public float startTime;
    public TextMeshProUGUI tm;
    
 
    // Start is called before the first frame update
    public void Start()
    {
        currentTime = startTime; 
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        tm.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

}
