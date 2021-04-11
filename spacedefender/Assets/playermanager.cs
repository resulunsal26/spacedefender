using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    [SerializeField] float movespeed;
    [SerializeField] float health = 100;
    [SerializeField] float projectilespeed;
    [SerializeField] float padding;
    [SerializeField] private GameObject laserprefab;
    float xmin, xmax;
    float ymin, ymax;
    // Start is called before the first frame update
    void Start()
    {
        padding = 0.6f;
        movespeed = 10;
        projectilespeed = 10f;
        setupmovebounderies();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        fire();
        
    }
    private void setupmovebounderies()
    {
        Camera camera = Camera.main;
        xmin = camera.ViewportToWorldPoint(new Vector3(0,0,0)).x+padding;
        xmax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        ymin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+padding; 
        ymax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-padding;
    }
    private void move()
    {
        var deltaX = Input.GetAxis("Horizontal")*Time.deltaTime*movespeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime*movespeed;
        var newxpos =Mathf.Clamp( transform.position.x + deltaX,xmin,xmax);
        var newypos =Mathf.Clamp( transform.position.y + deltaY,ymin,ymax);

        transform.position = new Vector2(newxpos, newypos);
    }
    private void fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Vector2 laserposition =new Vector2(transform.position.x, transform.position.y+ 0.58f);
          var laser =  Instantiate(laserprefab, laserposition, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectilespeed);
            Destroy(laser, 3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "playerlaser")
        {

        }
        else
        {
            damagedealer damagedealer = other.gameObject.GetComponent<damagedealer>();
            damagedealer.hit();
            processhit(damagedealer);
        }

    }
    public void processhit(damagedealer damagedealer)
    {
        health -= damagedealer.getdamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
