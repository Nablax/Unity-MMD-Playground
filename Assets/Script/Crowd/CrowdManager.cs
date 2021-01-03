using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{
    public GameObject[] crowdTypes;
    public int crowdRadius = 30;
    public int crowdNumber = 100;
    // Start is called before the first frame update
    public Transform dancer;
    void Start()
    {
        if(crowdTypes == null || crowdTypes.Length < 1){
            return;
        }
        int crowdTypeNum = crowdTypes.Length;
        int curCrowdType = 0;
        float rdAngle, rdRadius;
        var oriPosition = this.transform.position;
        for(int i = 0; i < crowdNumber; i++){
            rdAngle = Mathf.PI * Random.Range(0f, 1f) + Mathf.PI / 2;
            rdRadius = crowdRadius * Mathf.Sqrt(Random.Range(0f, 1f));
            Debug.Log(rdRadius);
            var obj = Instantiate(crowdTypes[curCrowdType]);
            obj.transform.position = oriPosition + new Vector3(rdRadius * Mathf.Cos(rdAngle), 0, rdRadius * Mathf.Sin(rdAngle));
            obj.transform.parent = this.transform;
            obj.transform.LookAt(dancer.transform.position);
            obj.transform.localScale *= 2;
            curCrowdType++;
            curCrowdType %= crowdTypeNum;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
