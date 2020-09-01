using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class WebMover : MonoBehaviour
{
    public InventoryObject inventory;
    public float Speed;
    private Vector3 movementVector = Vector3.zero;
    private GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        movementVector = (inventory.monsterclickedpos - transform.position).normalized * Speed;
        player = GameObject.Find("Player"); 
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
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
    void updateinfectionrecord()
    {
        inventory.Isbattle = true;
        inventory.isCaught = false;
        inventory.infectedallies += 1;
        //recored last check point
        inventory.initialvalue.x = player.transform.position.x;
        inventory.initialvalue.y = player.transform.position.y;
        inventory.initialvalue.z = player.transform.position.z;
        inventory.masktimer = GameObject.Find("InventoryController").GetComponent<InventoryController>().currentTime; 
    }
    IEnumerator PlayerEngage()
    {
        GameObject.Find("Crossfade").GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
