using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateenenmy : MonoBehaviour
{
    public GameObject enemy;
    public int xpos;
        public int zpos;
    public int enemycount;


    void Start()
    {
        StartCoroutine(enemydrop());
        
    }
    IEnumerator enemydrop(){
        while (enemycount<50)
        {
            xpos=Random.Range(778,5305);
            zpos=Random.Range(2868,5620);
            Instantiate(enemy,new Vector3(xpos,-150,zpos),Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemycount+=1;
        }
    }

 
    
}
