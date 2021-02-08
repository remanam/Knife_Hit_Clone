using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusObjects : MonoBehaviour
{
    public BonusObjectData baseBonusData;

    int knifeInLogCount;
    int knifeInLogChance; // 0-100%
    int appleInLogCount;
    int appleInLogChance; // 0-100%


    [SerializeField] GameObject logCenter;
    [SerializeField] GameObject apple;
    [SerializeField] GameObject knifeInLog;

    

    private void Start()
    {     
        SetBonusData();

        SpawnBonusObjects();
    }

    void SetBonusData()
    {

        knifeInLogCount = baseBonusData.knifeInLogCount;
        knifeInLogChance = baseBonusData.knifeInLogChance;

        appleInLogCount = baseBonusData.appleInLogCount;
        appleInLogChance = baseBonusData.appleInLogChance;
    }

    void SpawnBonusObjects()
    {
        Spawner spawner = new Spawner();
        Vector3 center = logCenter.transform.position;
       

        // make the object face the center
        
        var rot = Quaternion.Euler(0, 0, -spawner.GetAngle());

        for (int i = 0; i < baseBonusData.knifeInLogCount; i++) {
            if (Random.value >= knifeInLogChance / 100) {
                Vector3 pos = spawner.RandomCircle(center, apple.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2);
                GameObject knifeInLog = Instantiate(apple, pos, rot);
                knifeInLog.transform.SetParent(logCenter.transform);
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

    public int GetAngle()
    {
        return Convert.ToInt32(ang);
    }



}
