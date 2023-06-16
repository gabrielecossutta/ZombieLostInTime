using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class NemicoPiùVicino : Singleton<NemicoPiùVicino>
{
    public GameObject enemyContainer;
    public GameObject closestEnemy; // Riferimento nemico più vicino
    public GameObject[] childTransforms;
    public GameObject[] childTransforms2;
    public GameObject[] childTransforms3;
    public List<GameObject> allchildren;
    private void Start()
    {
        GameObject enemyContainer = GameObject.Find("EnemyContainer");
    }
    public void Update()
    {
        float closestDistance = 1000000f;
        //childTransforms = enemyContainer.GetComponentsInChildren<GameObject>(true);
        childTransforms = GameObject.FindGameObjectsWithTag("Enemy");
        childTransforms2 = GameObject.FindGameObjectsWithTag("EnemyBig");
        childTransforms3 = childTransforms.Concat(childTransforms2).ToArray();
        foreach (GameObject enemy in childTransforms3)
        {
            float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        //foreach (GameObject childTransform in childTransforms)
        //{
        //    allchildren.Add(childTransform); // li aggiungo alla lista
        //}
        //foreach (GameObject enemy in allchildren)
        //{
        //    float distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, enemy.transform.position);
        //    if (distance < closestDistance)
        //    {
        //        closestDistance = distance;
        //        GameObject closestEnemy = enemy;
        //    }
        //}


    }
}