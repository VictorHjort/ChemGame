using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aicustomer : MonoBehaviour
{
    public string Request, Success, Fail, Hint1, Hint2;
    public float ReqAtomMass;
    public int ReqAtomNumber, ReqFirstShell, ReqSecondShell, ReqThirdShell, ReqFourthShell, ReqFifthShell, ReqSixthShell, ReqSeventhShell;
    public int ReqGroup, ReqPeriod;
    public bool Hint1Bool = false, Hint2Bool = false, FailBool = false, TaskCompleted = false;

    public GameObject expectedObject;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("this works " + Request);
    }

    public void ReceiveObjectAtomNumber(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckAtomNumber(ReqAtomNumber))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckAtomNumber(ReqAtomNumber))
        {
            Wrong();
        }
    }
    public void ReceiveObjectAtomMass(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckMass(ReqAtomMass))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckMass(ReqAtomMass))
        {
            Wrong(); 
        }
    }
    public void ReceiveObjectGroup(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckGroup(ReqGroup))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckGroup(ReqGroup))
        {
            Wrong();
        }
    }
    public void ReceiveObjectPeriod(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckPeriod(ReqPeriod))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckPeriod(ReqPeriod))
        {
            Wrong();
        }
    }
    public void ReceiveObjectGroupeAndPeriod(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckGroup(ReqGroup) && receivedObject.GetComponent<Atom>().CheckPeriod(ReqPeriod))
        {
            correct();
        }
        if(receivedObject.GetComponent<Atom>().CheckGroup(ReqGroup))
        {
            Wrong();
        }
        if(!receivedObject.GetComponent<Atom>().CheckPeriod(ReqPeriod))
        {
            Wrong();
        }
    }
    public void ReceiveObjectFirstShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckFirst(ReqFirstShell))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckFirst(ReqFirstShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectSecondShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckSecond(ReqSecondShell))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckSecond(ReqSecondShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectThirdShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckThird(ReqThirdShell))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckThird(ReqThirdShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectFourthShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckFourth(ReqFourthShell))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckFourth(ReqFourthShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectFifthShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckFifth(ReqFifthShell))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckFifth(ReqFifthShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectSixthShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckSixth(ReqSixthShell))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckSixth(ReqSixthShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectSeventhShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckSeventh(ReqSeventhShell))
        {
            correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckSeventh(ReqSeventhShell))
        {
            Wrong();
        }
    }
    public void correct()
    {
        Debug.Log(Success);
    }

    public void Wrong()
    {
        if (FailBool)
        {
            Debug.Log(Fail);
        }
        if (Hint2Bool)
        {
            Debug.Log(Hint2);
            Hint2Bool = false;
            FailBool = true;
        }
        if (Hint1Bool)
        {
            Debug.Log(Hint1);
            Hint1Bool = false;
            Hint2Bool = true;
        }
    }

}
