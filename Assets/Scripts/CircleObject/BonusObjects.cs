using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BonusObjects : MonoBehaviour
{
    public BonusObjectData baseBonusData;

    int maximumKnifeInLogCount;
    int knifeInLogChance; // 0-100%
    int minimalKnifeCount;

    int appleInLogCount;
    int appleInLogChance; // 0-100%


    [SerializeField] GameObject logCenter;

    [SerializeField] GameObject knifeInLog;
    [SerializeField] GameObject apple;


    

    private void Start()
    {    
        
        SetBonusData();
        
        SpawnBonusObjects(apple, 0, appleInLogCount, appleInLogChance);
        SpawnBonusObjects(knifeInLog, minimalKnifeCount, maximumKnifeInLogCount, knifeInLogChance);


    }

    //DEBUGGING
/*    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }*/

    void SetBonusData()
    {
        minimalKnifeCount = baseBonusData.minimalKnifeCount;
        maximumKnifeInLogCount = baseBonusData.maximumKnifeCount;
        knifeInLogChance = baseBonusData.knifeInLogChance;
        

        appleInLogCount = baseBonusData.appleInLogCount;
        appleInLogChance = baseBonusData.appleInLogChance;
    }

    void SpawnBonusObjects(GameObject objectToSpawn, int minimalObjectToSpawn, int maximumObjectscount, int chanceToSpawn)
    {
        Spawner spawner = new Spawner();
        Vector3 center = logCenter.transform.position;

        int minCount = 0; // Переменная чтоб хранить количество минимальных Instantiate
        
        

        for (int i = 0; i < maximumObjectscount - minimalObjectToSpawn; i++) { // Отнимаем минимальное количество, чтоб они всегда спавнились

            float chance = Random.value;

            // Условие для создания минимального количества объектов
            if (minCount < minimalObjectToSpawn) {
                

                Vector3 pos = spawner.RandomCircle(center, logCenter.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.x * logCenter.transform.localScale.x / 2);
                var rot = Quaternion.Euler(0, 0, 180 - spawner.GetAngle());

                Debug.Log("Sprite Bound = " + logCenter.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2);
                Debug.Log("Sprite Angle = " + spawner.GetAngle());

                if (Physics.CheckSphere(pos, 1f)) {
                    
                }
                else {
                    // spot is empty, we can spawn
                    GameObject _objectToSpawn = Instantiate(objectToSpawn, pos, rot);
                    _objectToSpawn.transform.SetParent(logCenter.transform);
                }

                minCount++;
            }

            // Условие появления объекта с шансом
            if (chance <= (float)chanceToSpawn / 100) {


                Vector3 pos = spawner.RandomCircle(center, logCenter.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.x * logCenter.transform.localScale.x / 2);
                var rot = Quaternion.Euler(0, 0, 180 - spawner.GetAngle());

                Debug.Log("Sprite Bound = " + logCenter.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2);
                Debug.Log("Sprite Angle = " + spawner.GetAngle());

                if (Physics.CheckSphere(pos, 1f)) {
                    
                }
                else {
                    // spot is empty, we can spawn
                    GameObject _objectToSpawn = Instantiate(objectToSpawn, pos, rot);
                    _objectToSpawn.transform.SetParent(logCenter.transform);
                }


            }
        }

        //GameObject appleObject = Instantiate(apple, pos, rot);
        //appleObject.transform.SetParent(logCenter.transform);
    }

}

public class Spawner
{
    float ang;
    

    public Vector3 RandomCircle(Vector3 center, float radius)
    {
        // create random angle between 0 to 360 degrees 
        ang = UnityEngine.Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;

    }

    public float GetAngle()
    {
        return ang;
    }



}
