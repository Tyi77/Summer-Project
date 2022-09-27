using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyArea : MonoBehaviour
{
    [SerializeField] private Transform areaPoint1;
    [SerializeField] private Transform areaPoint2;
    [SerializeField] private GameObject supply;

    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    private void Start() {
        if(areaPoint1.position.x <= areaPoint2.position.x){
            minX = areaPoint1.position.x;
            maxX = areaPoint2.position.x;
        }else{
            minX = areaPoint2.position.x;
            maxX = areaPoint1.position.x;
        }
        if(areaPoint1.position.z <= areaPoint2.position.z){
            minZ = areaPoint1.position.z;
            maxZ = areaPoint2.position.z;
        }else{
            minZ = areaPoint2.position.z;
            maxZ = areaPoint1.position.z;
        }
    }

    private int supplyNum = 0;
    private int maxNum = 20;

    private void Update() {
        if(supplyNum < maxNum){
            GameObject supplyClone = Instantiate(supply.gameObject, new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ)), Quaternion.Euler(Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f), Random.Range(0.0f, 180.0f)));
            supplyClone.GetComponent<Supply>().destroyEvent += subSupply;
            supplyClone.transform.parent = transform;
            supplyNum++;
        }
    }

    private void subSupply(){
        supplyNum--;
    }

}
