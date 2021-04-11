using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave/Enemy Wave Config")]
public class wave : ScriptableObject
{
    [SerializeField] GameObject enemyprefab;
    [SerializeField] GameObject pathprefab;
    [SerializeField] float timebetweenspawn=0.5f;
    [SerializeField] float spawnrandomfactor = 0.3f;
    [SerializeField] int numberofenemies = 5;
    [SerializeField] float movespeed = 2f;
    public GameObject getenemyprefab() { return enemyprefab; }
    public List<Transform> getwaypoints() {

        var waypoints = new List<Transform>();
        foreach(Transform child in pathprefab.transform )
        {
            waypoints.Add(child);
        }
        return waypoints;
    
    }
    public float gettimebetweenspawn() { return timebetweenspawn; }
    public float getspawnrandomfactor() { return spawnrandomfactor; }
    public int getnumberofenemies() { return numberofenemies; }
    public float getmovespeed() { return movespeed; }


}
