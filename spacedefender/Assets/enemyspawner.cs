using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    [SerializeField] List<wave> wave;
    [SerializeField] bool looping=false;
    int startingwave = 0;
    private void Awake()
    {
        var currentwave = wave[startingwave];
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
           yield return StartCoroutine(spawnallwaves());
        } while (looping);
      
    }
    private IEnumerator spawnallwaves()
    {
       
        for(int waveindex=0;waveindex<wave.Count;waveindex++)
        {
            var currentwave = wave[waveindex];
           
           yield return StartCoroutine(spawallenemiesinwave(currentwave));
        }
    }
   
    // Update is called once per frame
    private IEnumerator spawallenemiesinwave(wave currentwave)
    {
        for(int enemycount=0;enemycount<currentwave.getnumberofenemies(); enemycount++)
        {
          var newenemy=  Instantiate(currentwave.getenemyprefab(), currentwave.getwaypoints()[0].position, Quaternion.identity) as GameObject;
            newenemy.GetComponent<enemymanager>().setwaveconfig(currentwave);
            yield return new WaitForSeconds(currentwave.gettimebetweenspawn());
        }
      
    }
}
    