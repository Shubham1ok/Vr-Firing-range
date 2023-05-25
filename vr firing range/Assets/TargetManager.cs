using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public int Level;
    public GameObject[] targetPrefabs;
    public GameObject[] targets;
    public int RoundCounter,MaxRounds;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTargets();
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
        SpawnTargets();
        Debug.Log("Targets reset");
    }
    public void disableColliders()
    {
        foreach (var item in targets)
        {
            item.GetComponent<Collider>().enabled = false;
        }
    }
    public void SpawnTargets()
    {
        RoundCounter++;
        if (RoundCounter <= MaxRounds)
        {
            int i = 0;
            int r = Random.Range(0, targets.Length);
            switch (Level)
            {
                case 0://only pop up and go down when shot

                    foreach (var item in targets)
                    {
                        i++;
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = false;
                        item.GetComponent<TargetMove>().bshouldMove = false;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = false;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                        }
                    }
                    break;
                case 1://only pop up and go down after some time
                    i = 0;
                    r = Random.Range(0, targets.Length);
                    foreach (var item in targets)
                    {
                        i++;
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = true;
                        item.GetComponent<TargetMove>().bshouldMove = false;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = false;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                        }
                    }
                    break;
                case 2://only pop up and go move
                    i = 0;
                    r = Random.Range(0, targets.Length);
                    foreach (var item in targets)
                    {
                        i++;
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = false;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMove = true;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = false;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                        }
                    }
                    break;
                case 3://pop up and move and go down
                    i = 0;
                    r = Random.Range(0, targets.Length);
                    foreach (var item in targets)
                    {
                        i++;
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = true;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMove = true;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = false;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                        }
                    }
                    break;
                case 4://pop up and move and go down
                    i = 0;
                    r = Random.Range(0, targets.Length);
                    foreach (var item in targets)
                    {
                        i++;
                        item.SetActive(true);
                        item.GetComponent<TargetMove>().popUpTimer = 3;
                        item.GetComponent<TargetMove>().bshouldGoDown = true;
                        item.GetComponent<TargetMove>().TargetPoppedUp = false;
                        item.GetComponent<TargetMove>().bshouldMove = true;
                        item.GetComponent<TargetMove>().bshouldMoveRandom = true;
                        item.GetComponent<TargetMove>().speed = Random.Range(3, 8);
                        item.GetComponent<TargetMove>().goDownTimer = 5;
                        item.GetComponent<Collider>().enabled = true;
                        if (i == r)
                        {
                            item.GetComponent<TargetMove>().isCorrect = 1;
                        }
                        else
                        {
                            item.GetComponent<TargetMove>().isCorrect = 0;
                        }
                    }
                    break;


            }
        }
        
    }
}
