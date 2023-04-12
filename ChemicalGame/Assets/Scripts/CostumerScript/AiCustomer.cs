using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AiCustomer : MonoBehaviour
{

    //Variables for text transfer
    public TMP_Text forTextField;
    //public GameObject textField;
    //private TMP_Text testText;

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

    public string Request, Success, Fail, Hint1, Hint2;
    public float ReqAtomMass;
    public int ReqAtomNumber, ReqFirstShell, ReqSecondShell, ReqThirdShell, ReqFourthShell, ReqFifthShell, ReqSixthShell, ReqSeventhShell;
    public int ReqGroup, ReqPeriod;
    public bool Hint1Bool = true, Hint2Bool = false, FailBool = false, TaskCompleted = false;
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
            forTextField.text = Request; 


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
        if (CustommerTask == 0)
        {
            ReceiveObjectGroup(receivedObject);

        }
        if (CustommerTask == 1)
        {
            ReceiveObjectPeriod(receivedObject);
        }

        if (CustommerTask == 2)
        {
            ReceiveObjectGroupeAndPeriod(receivedObject);
        }
        if (CustommerTask == 3)
        {
            ReceiveObjectGroupeAndPeriod(receivedObject);
        }
        if (CustommerTask == 4)
        {
        }
        if (CustommerTask == 5)
        {
            ReceiveObjectAtomMass(receivedObject);
        }
        if (CustommerTask == 6)
        {
        }
    }
    /*
     * 
     * Det her er functionerne der kører hvis svaret er rigtigt -
     * Correct, eller forkert - Wrong.
     * Hvis svaret er korrekt så køre funktionen Correct()
     * Hvis svaret derimod er forkert køre funktionen Wrong() 
     */

    
    
    /*
     * Disse Functioner checker om det gældende krav er Correct i Atommerne.
     * den tilgår det object der valgt "receivedObject" og tilgår dens script 
     * "Atom" i den er der functioner der checker om det er Correct og sender 
     * en bool tilbage der enten er true eller false hvis den er true så køre
     * functionen Correct() som er længere oppe i teksten.
     */

    public void ReceiveObjectAtomNumber(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckAtomNumber(ReqAtomNumber))
        {
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
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
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckSeventh(ReqSeventhShell))
        {
            Wrong();
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
    public void Correct()
    {
        forTextField.text = Success;
    }

    public void Wrong()
    {
        if (FailBool)
        {
            print(Fail); //fail dialog text
            //leaving and get new ai
            forTextField.text = Fail;
        }
        if (Hint2Bool)
        {
            print(Hint2); //hint 2 text
            Hint2Bool = false;
            FailBool = true;
            forTextField.text = Hint2;
        }
        if (Hint1Bool)
        {
            print(Hint1); //hint 1 text
            Hint1Bool = false;
            Hint2Bool = true;
            forTextField.text = Hint1;
        }
    }
}
