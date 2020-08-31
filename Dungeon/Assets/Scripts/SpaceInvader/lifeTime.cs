using System.Collections;
using TMPro;
using UnityEngine;

public class lifeTime : MonoBehaviour
{
    public int LifeTime;
    public SpriteRenderer SR;
    public Animator animator;
    public GameObject percentage;
    public int percent;
    private GameObject UIcontroller; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
        Destroy(percentage, LifeTime);
        percentage.GetComponent<TextMeshProUGUI>().text = "100%";
        percent = 100;
        UIcontroller = GameObject.Find("UIcontroller");
        percentage.transform.parent = UIcontroller.transform; 
    }

    void Update()
    {
        if (percent == 0)
        {
            Destroy(gameObject);
            Destroy(percentage); 
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Virus")
        {
            Destroy(collider.gameObject); 
        }
        if (collider.gameObject.tag == "Potion")
        {
            SR.color = new Color(SR.color.r, SR.color.g + 25.5f / 255f, SR.color.b + 25.5f / 255f);
            if (percent >= 100)
            {
                percent = 100;
                percentage.GetComponent<TextMeshProUGUI>().text = percent.ToString("0") + "%";
            }
            else
            {
                percent += 10;
                percentage.GetComponent<TextMeshProUGUI>().text = percent.ToString("0") + "%";
            }
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Allies")
        {
            if (collision.gameObject.GetComponent<wolfBehavior>().IsInfected)
            {
                SR.color = new Color(SR.color.r, SR.color.g - 25.5f/255f, SR.color.b - 25.5f / 255f);
                percent -= 10;
                percentage.GetComponent<TextMeshProUGUI>().text = percent.ToString("0") + "%";
            }
        }
    }
}
