using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public int Level;
    public GameObject[] targetPrefabs;
    public GameObject[] targets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void CheckHit(int HitValue)
    {
        if(HitValue==0)
        {
            Debug.Log("correct hit");
        }
        else
        {
            Debug.Log("Wrong hit");
        }
        Invoke(nameof(ResetTargets),3f);
    }
    public void ResetTargets()
    {
        foreach (var item in targets)
        {
            item.GetComponent<TargetMove>().resetValues();
            item.SetActive(false);
        }
        Debug.Log("Targets reset");
    }
}
