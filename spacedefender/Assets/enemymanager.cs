using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymanager : MonoBehaviour
{
     wave wave;
     float movespeed=2f;
    int waypointindex=0;
    List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = wave.getwaypoints();
        transform.position = waypoints[waypointindex].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
       if(waypointindex<=waypoints.Count-1)
        {
            var targetposition = waypoints[waypointindex].position;
            var movementthisframe = movespeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetposition, movementthisframe);
            if(transform.position==targetposition)
            {
                waypointindex++;
            }
        }
       else
        {
            Destroy(gameObject);
        }
    }
    public void setwaveconfig(wave wave)
    {
        this.wave = wave;
        movespeed = this.wave.getmovespeed();
    }
}
