using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class WebMover : MonoBehaviour
{
    public InventoryObject inventory;
    public float Speed;
    private Vector3 movementVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = (inventory.monsterclickedpos - transform.position).normalized * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementVector * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            inventory.enemyTag.Add(collision.gameObject.transform.parent.tag);
            updateinfectionrecord();
            StartCoroutine(PlayerEngage());
        }
    }
    void updateinfectionrecord()
    {
        inventory.Isbattle = true;
        inventory.isCaught = false;
        inventory.infectedallies += 1;
        //recored last check point
        inventory.initialvalue.x = transform.position.x;
        inventory.initialvalue.y = transform.position.y;
        inventory.initialvalue.z = transform.position.z;
        inventory.masktimer = GameObject.Find("InventoryController").GetComponent<InventoryController>().currentTime; 
    }
    IEnumerator PlayerEngage()
    {
        GameObject.Find("Crossfade").GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
