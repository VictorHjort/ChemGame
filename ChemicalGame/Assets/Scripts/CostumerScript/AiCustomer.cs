using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AiCustomer : MonoBehaviour
{


    //Variables for modifying text
    [Header("The Text Field")]
    public TMP_Text forTextField;

    private ScientistController scientistController;


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
    public enum TextStyle
    {
        StringAtomnameStringGroupString,
        StringAtomnameStringAtomnumberString,
        StringAtomnumberStringAtomnameString
    }

    [SerializeField] [Header("The AI's Task")] Dropdown Tasks;
    [SerializeField] [Header("Dialog")]
    public string Request;
    public string Success;
    public string Failure;

    [SerializeField] [Header("TekstDisplay (Husk MellemRum)")] TextStyle TekstStyle;
    public string Hint1Part1;
    public string Hint1Part2;
    public string Hint1Part3;
    public string Hint2Part1;
    public string Hint2Part2;
    public string Hint2Part3;

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
    
    [System.NonSerialized] public bool Hint1Bool = true, Hint2Bool = false, FailBool = false, TaskCompleted = false;
    [System.NonSerialized] private int CustommerTask, AtomGroup, AtomNumber;
    [System.NonSerialized] public string Hint1, Hint2, AtomName;
    [System.NonSerialized] public AiCustomerManager theAIManagaer;


    public void Start()
    {
        theAIManagaer = FindObjectOfType<AiCustomerManager>();
        CustommerTaskSet();
        forTextField.text = Request;
        scientistController = GetComponent<ScientistController>();
    }
    // Update is called once per frame
    void Update()
    {
      // print(Tasks);
    }


    /*
     * Her bliver Hint 1 og Hint 2's format lavet, altså ex. string + atomname + string + atomnumber + string 
     * 
     */
    public void textStyleChoice(GameObject receivedObject)
    {
        AtomName = receivedObject.GetComponent<Atom>().AtomName;
        AtomGroup = receivedObject.GetComponent<Atom>().Group;
        AtomNumber = receivedObject.GetComponent<Atom>().AtomNumber;

        if (TekstStyle == TextStyle.StringAtomnameStringGroupString)
        {
            Hint1 = Hint1Part1  + AtomName + Hint1Part2 + AtomGroup + Hint1Part3;
            Hint2 = Hint2Part1  + AtomName + Hint2Part2 + AtomGroup  + Hint2Part3;

        }
        if (TekstStyle == TextStyle.StringAtomnameStringAtomnumberString)
        {
            Hint1 = Hint1Part1  + AtomName + Hint1Part2  + AtomNumber + Hint1Part3;
            Hint2 = Hint2Part1  + AtomName + Hint2Part2  + AtomNumber + Hint2Part3;
        }
        if(TekstStyle == TextStyle.StringAtomnumberStringAtomnameString)
        {
            Hint1 = Hint1Part1  + AtomNumber + Hint1Part2  + AtomName  + Hint1Part3;
            Hint2 = Hint2Part1  + AtomNumber + Hint2Part2  + AtomName  + Hint2Part3;

        }


    }



    /*
     * Her bliver CustommerTask tildelt
     * CustommerTask = 0 i Group og CustommerTask = 1 i Period.
     * for overblik er
     * 0 = Group
     * 1 = Period
     * 2 = Group And Period
     * 3 = Akali Metaller
     * 4 = Atom Opbygning,
     * 5 = Atom Masse
     * 6 = Ellektroner I Yderste Skald
     * 
     */
    public void CustommerTaskSet()
    {
        if (Tasks == Dropdown.Group)
        {
            CustommerTask = 0;
            

        }
        else if (Tasks == Dropdown.Period)
        {
            CustommerTask = 1;
            
        }
        else if (Tasks == Dropdown.GroupAndPeriod)
        {
            CustommerTask = 2;
            
        }
        else if (Tasks == Dropdown.AkaliMetaler)
        {
            CustommerTask = 3;
            

        }
        else if (Tasks == Dropdown.AtomOpbygning)
        {
            CustommerTask = 4;
            
        }
        else if (Tasks == Dropdown.AtomMasse)
        {
            CustommerTask = 5;
            
        }
        else if (Tasks == Dropdown.EllektronerIYdersteSkald)
        {
            CustommerTask = 6;
            
        }
    }
    /*
     * Her bliver løsningen valgt udfra hvad man vælger Group,Period,GroupAndPeriod ETC.
     * det bliver valgt ud fra int CustommerTask, I drop down Menu er Group = 0 Period = 1 osv.
     * så fra top til bunden, går det fra 0 til 6 (atm)
     * se listen ovenover.
     * 
     */
    public void CustommerRecieved(GameObject receivedObject)
    {
        textStyleChoice(receivedObject);

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
            ReceiveObjectOuterShell(receivedObject);
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
        forTextField.text = Success;
        scientistController.correctAnswer = true;
        scientistController.doneWithTask = true;
    }

    public void Wrong()
    {
        if (FailBool)
        {
            //leaving and get new ai
            forTextField.text = Failure;
            
        }
        if (Hint2Bool)
        {
            Hint2Bool = false;
            FailBool = true;
            forTextField.text = Hint2;
        }
        if (Hint1Bool)
        {
            Hint1Bool = false;
            Hint2Bool = true;
            forTextField.text = Hint1;
        }
    }
    public void setRequest()
    {
        forTextField.text = Request;
    }
}
