using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotcount;
    [SerializeField] float mintimebetweenshot=0.2f;
    [SerializeField] float maxtimebetweenshot = 0.3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectilespeed=10f;
    private void Start()
    {
        shotcount = Random.Range(mintimebetweenshot, maxtimebetweenshot);
    }
    private void Update()
    {
        countdownandshoot();
    }
    public void countdownandshoot()
    {
        shotcount -= Time.deltaTime;
        if(shotcount<=0f)
        {
            fire();
            shotcount = Random.Range(mintimebetweenshot, maxtimebetweenshot);
        }
    }
    public void fire()
    {
        Vector2 laserposition = new Vector2(transform.position.x, transform.position.y - 0.58f);
        var laser = Instantiate(projectile, laserposition, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectilespeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag=="enemylaser")
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
        if(health<=0)
        {
            Destroy(gameObject);
        }
       
    }
}
