using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagedealer : MonoBehaviour
{
    [SerializeField] int damage=20;
   
    public int getdamage()
    {
        return damage;
    }
    public void hit()
    {
        Destroy(gameObject);
    }
}
