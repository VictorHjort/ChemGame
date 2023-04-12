using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCustomer : MonoBehaviour
{

    public enum Dropdown
    {
        Group,
        Period,
        GroupAndPeriod,
        AkaliMetaler,
        AtomOpbygning,
        AtomMasse,
        EllektronerIYdersteSkald
    }
    [SerializeField] Dropdown Tasks;

    [Header("Dialog")]
    public string Request;
    public string Success;
    public string Hint1;
    public string Hint2;
    public string Failure;

    [Header("Group, Period & Group And Period")]
    public int RequestedGroup;
    public int RequestedPeriod;

    [Header("Atom Opbygnind")]
    public int RequestedAtomNumber;

    [Header("Atom Masse")]
    public float RequestedAtomMass;

    [Header("Ellektroner I YdersteSkald")]
    public int RequestedOuterShell;

    [Header("Ingen ide lige nu ^^' ")]
    public int RequestedFirstShell;
    public int RequestedSecondShell;
    public int RequestedThirdShell;
    public int RequestedFourthShell;
    public int RequestedFifthShell;
    public int RequestedSixthShell;
    public int RequestedSeventhShell;
    
    [System.NonSerialized]
    public bool Hint1Bool = false, Hint2Bool = false, FailBool = false, TaskCompleted = false;
    private int CustommerTask;
    public AiCustomerManager theAIManagaer;


    public void Start()
    {
        theAIManagaer = FindObjectOfType<AiCustomerManager>();
        CustommerTaskSet();
    }
    // Update is called once per frame
    void Update()
    {
      // print(Tasks);
    }

    public void CustommerTaskSet()
    {
        if (Tasks == Dropdown.Group)
        {
            CustommerTask = 0;
            print(CustommerTask);

        }
        else if (Tasks == Dropdown.Period)
        {
            CustommerTask = 1;
            print(CustommerTask);
        }
        else if (Tasks == Dropdown.GroupAndPeriod)
        {
            CustommerTask = 2;
            print(CustommerTask);
        }
        else if (Tasks == Dropdown.AkaliMetaler)
        {
            CustommerTask = 3;
            print(CustommerTask);

        }
        else if (Tasks == Dropdown.AtomOpbygning)
        {
            CustommerTask = 4;
            print(CustommerTask);
        }
        else if (Tasks == Dropdown.AtomMasse)
        {
            CustommerTask = 5;
            print(CustommerTask);
        }
        else if (Tasks == Dropdown.EllektronerIYdersteSkald)
        {
            CustommerTask = 6;
            print(CustommerTask);
        }
    }
    public void CustommerRecieved(GameObject receivedObject)
    {
        print(receivedObject.GetComponent<Atom>().AtomName);
        if (CustommerTask == 0)
        {
            ReceiveObjectGroup(receivedObject);
            print("what 1");
        }
        if (CustommerTask == 1)
        {
            ReceiveObjectPeriod(receivedObject);
            print("what 2");
        }

        if (CustommerTask == 2)
        {
            ReceiveObjectGroupeAndPeriod(receivedObject);
            print("what 3");
        }
        if (CustommerTask == 3)
        {
            ReceiveObjectGroupeAndPeriod(receivedObject);
            print("what 4");
        }
        if (CustommerTask == 4)
        {
            print("wha 5");
        }
        if (CustommerTask == 5)
        {
            ReceiveObjectAtomMass(receivedObject);
            print("what 6");
        }
        if (CustommerTask == 6)
        {
            ReceiveObjectOuterShell(receivedObject);
            print("what 7");
        }
    }

    
    
    /*
     * Disse Functioner checker om det gældende krav er Correct i Atommerne.
     * den tilgår det object der valgt "receivedObject" og tilgår dens script 
     * "Atom" i den er der functioner der checker om det er Correct og sender 
     * en bool tilbage der enten er true eller false hvis den er true så køre
     * functionen Correct() som er længere oppe i teksten.
     */

    public void ReceiveObjectAtomNumber(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckAtomNumber(RequestedAtomNumber))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckAtomNumber(RequestedAtomNumber))
        {
            Wrong();
        }
    }
    public void ReceiveObjectAtomMass(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckMass(RequestedAtomMass))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckMass(RequestedAtomMass))
        {
            Wrong(); 
        }
    }
    public void ReceiveObjectGroup(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckGroup(RequestedGroup))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckGroup(RequestedGroup))
        {
            Wrong();
        }
    }
    public void ReceiveObjectPeriod(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckPeriod(RequestedPeriod))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckPeriod(RequestedPeriod))
        {
            Wrong();
        }
    }
    public void ReceiveObjectGroupeAndPeriod(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckGroup(RequestedGroup) && receivedObject.GetComponent<Atom>().CheckPeriod(RequestedPeriod))
        {
            Correct();
        }
        if(receivedObject.GetComponent<Atom>().CheckGroup(RequestedGroup))
        {
            Wrong();
        }
        if(!receivedObject.GetComponent<Atom>().CheckPeriod(RequestedPeriod))
        {
            Wrong();
        }
    }
    public void ReceiveObjectFirstShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckFirst(RequestedFirstShell))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckFirst(RequestedFirstShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectSecondShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckSecond(RequestedSecondShell))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckSecond(RequestedSecondShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectThirdShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckThird(RequestedThirdShell))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckThird(RequestedThirdShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectFourthShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckFourth(RequestedFourthShell))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckFourth(RequestedFourthShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectFifthShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckFifth(RequestedFifthShell))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckFifth(RequestedFifthShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectSixthShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckSixth(RequestedSixthShell))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckSixth(RequestedSixthShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectSeventhShell(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckSeventh(RequestedSeventhShell))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckSeventh(RequestedSeventhShell))
        {
            Wrong();
        }
    }
    public void ReceiveObjectOuterShell(GameObject receivedObject)
    {
        print(receivedObject.GetComponent<Atom>().Shells);
        if (receivedObject.GetComponent<Atom>().CheckOuterShell(RequestedOuterShell, receivedObject.GetComponent<Atom>().Shells))
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckOuterShell(RequestedOuterShell, receivedObject.GetComponent<Atom>().Shells))
        {
            Wrong();
            print(receivedObject.GetComponent<Atom>().Shells);
        }
    }

    public void SetHint1Bool(bool WhatState)
    {
        Hint1Bool = WhatState;
    }
    public void SetFailBool(bool WhatState)
    {
        FailBool = WhatState;
    }

    /*
    * 
    * Det her er functionerne der kører hvis svaret er rigtigt -
    * Correct, eller forkert - Wrong.
    * Hvis svaret er korrekt så køre funktionen Correct()
    * Hvis svaret derimod er forkert køre funktionen Wrong() 
    */
    public void Correct()
    {
        Debug.Log(Success);
    }

    public void Wrong()
    {
        
        if (Hint1Bool)
        {
            print(Hint1); //hint 1 text
            Hint1Bool = false;
            Hint2Bool = true;
        }
        else if (Hint2Bool)
        {
            print(Hint2); //hint 2 text
            Hint2Bool = false;
            FailBool = true;
        }
        else if (FailBool)
        {
            print(Failure); //fail dialog text
            //leaving and get new ai
        }

        else
        {
            Hint1Bool = true;
        }
    }
}
