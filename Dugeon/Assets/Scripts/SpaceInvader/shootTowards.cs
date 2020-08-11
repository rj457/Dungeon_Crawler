using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootTowards : MonoBehaviour
{
    public GameObject aimCursor;
    Vector2 mousePos;
    public Scroller scroller;
    public InventoryObject inventory;
    private float maskcooldown = 11;
    //mask properties 
    public GameObject spawnposition;
    public GameObject maskPrefab;
    public Vector3 clickedposition; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        updateAim();
        checkmousepress();
    }
    void updateAim()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimCursor.transform.position = mousePos; 
    }
    void checkmousepress()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            //if mask been selected shoot mask out
            if (scroller.indication == 1)
            {
                if (inventory.maskcounts > 0 && maskcooldown > 10)
                {
                    maskcooldown = 0;
                    //instainate this prefab
                    Instantiate(maskPrefab,spawnposition.transform.position,Quaternion.identity);
                    //fly towards mouse position without stop 
                    clickedposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    StartCoroutine(skillmask());
                }
            }
        }
    }
    IEnumerator skillmask()
    {
        yield return new WaitForSeconds(2);
        maskcooldown = 11;
    }
}
