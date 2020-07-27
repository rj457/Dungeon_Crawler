using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class countDownTimer : MonoBehaviour
{
    public float currentTime=1f;
    public float startTime;
    public TextMeshProUGUI tm;
    public ButtonController bc;
    public bool isend = false;
 
    // Start is called before the first frame update
    public void Start()
    {
        currentTime = startTime; 
    }

    // Update is called once per frame
    private void Update()
    {
        if (bc.Onstart) {
            
            currentTime -= 1 * Time.deltaTime;
            tm.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
                isend = true;
                bc.Onstart = false;
            }
        }
    }
}
