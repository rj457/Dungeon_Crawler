using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cursorBarrel : MonoBehaviour
{
    public bool isbarrelclick;
    public DragandDrop cursorcontroller;
    public GameObject rockPrefab;
    public GameObject player;
    public float rockspeed = 2f;
    private bool istouchingrock;
    public InventoryObject inventory;
    public TextMeshProUGUI rockcounts; 
    public GameObject equipemptywarning;
    public List<GameObject> supplies; 
    // Update is called once per frame
    void Update()
    {
        if (isbarrelclick && GameObject.Find("RockSolid(Clone)") != null)
        {
            GameObject.Find("RockSolid(Clone)").transform.position = Vector2.MoveTowards(GameObject.Find("RockSolid(Clone)").transform.position, new Vector2(transform.position.x, transform.position.y), rockspeed * Time.deltaTime);
            if (istouchingrock)
            {
                isbarrelclick = false; 
            }
        }
        
    }
    public void OnMouseEnter()
    {
        cursorcontroller.enableaim(); 
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal(); 
    }
    public void OnMouseDown()
    {
        isbarrelclick = true;
        if (GameObject.Find("RockSprite(Clone)") != null && inventory.rockcounts > 0)
        {
            Vector3 spawnposition = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
            Instantiate(rockPrefab, spawnposition, Quaternion.identity);
            inventory.rockcounts -= 1;
            rockcounts.text = inventory.rockcounts.ToString("0");
        }
        else
        {
            StartCoroutine(showemptysign());
            isbarrelclick = false; 
        }
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            istouchingrock = true;
            //Randomly sqawn supplies
            GameObject supply = supplies[Random.Range(0, supplies.Count)];
            //Then instainiate
            Instantiate(supply, transform.position, Quaternion.identity);
            //Then destory this barrel 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    IEnumerator showemptysign()
    {
        equipemptywarning.SetActive(true);
        yield return new WaitForSeconds(3f);
        equipemptywarning.SetActive(false); 
    }
}
