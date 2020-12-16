using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MusicChecker : MonoBehaviour
{
    [System.Serializable]
    public class OnRewardEvent : UnityEvent { };
    public OnRewardEvent onReward;
    public List<KeyName> goal = new List<KeyName>();
    private List<KeyName> cur = new List<KeyName>();
    private List<CheckLED> checkLEDs = new List<CheckLED>();
    public GameObject checkLED;
    public Transform ledField;

    bool _isRight = false;

    private int order = 0;
    public bool isRight
    {
        get => _isRight;
        set
        {
            _isRight = value;
            if (_isRight) StageEventManager.instance.InvokeEvent(0);
        }
    }

    private void Start()
    {
        float offset = -0.17f;
        for(int i =0; i < goal.Count; i++)
        {
            GameObject temp = Instantiate(checkLED,ledField);
            temp.transform.localPosition = new Vector3(0, offset * i, 0);
            checkLEDs.Add(temp.GetComponent<CheckLED>());

        }
    }
    public void ResetCur()
    {
        cur.Clear();
        print("reset cur");
        for(int i=0; i < checkLEDs.Count; i++)
        {
            checkLEDs[i].State = CheckLED.state.Off;
        }
    }
    public void AddCurKey(KeyName key)
    {
        bool check = true;
        
        if(cur.Count < goal.Count)
        {
            cur.Add(key);
        }
        else
        {
            order = order % cur.Count;
            cur[order] = key;
        }
        for(int i =0; i < goal.Count;i++)
        {
            if(i >= cur.Count)
            {
                checkLEDs[i].State = CheckLED.state.Off;
                check = false;
            }
            else
            {
                if (goal[i] != cur[i])
                {
                    check = false;
                    checkLEDs[i].State = CheckLED.state.Wrong;
                }
                else
                {
                    checkLEDs[i].State = CheckLED.state.Right;
                }
            }
  
            
        }
        if (check) isRight = true;
        order++;
    }

 
}
