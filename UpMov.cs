using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpMov : MonoBehaviour
{
    public Text uiText;

    public GameObject movObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider !=null&&Input.GetMouseButtonDown(0))//Raycasting
        {
            Debug.Log(hit.collider.tag); 
            hit.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400);//Physcis and adding force
            uiText.text = "The height\n"+hit.collider.transform.position.y.ToString();
            hit.transform.position = new Vector3(hit.transform.position.x+5,hit.transform.position.y,hit.transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//Meant to detect collision between objects
    {
        if (collision.collider.tag == "Player")//if the object that's touching the cube has the tag of "Plactform"
        {//Line above is collision
            //Destory or remove the object that touches the cube from the game
            GameObject newObj = Instantiate(collision.gameObject,collision.transform.position,collision.transform.rotation);
            Destroy(collision.gameObject);
            newObj.GetComponent<Collider2D>().enabled = true;
            //Line above is instantition
            //newObj.GetComponent<Rigidbody2D>().AddForce(Vector2.up*400);
        }
        else
        {
            Debug.Log("None");
        }
    }
}
