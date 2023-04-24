using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class AiCustomer : MonoBehaviour
{


    //Variables for modifying text
    [Header("The Text Field")]
    public TMP_Text forTextField;
    private bool[] Akalibool ;
    private ScientistController scientistController;
    public GameObject playerC;
    PlayerController playerController;
    
    

    // enum that changes how the task is procced
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
    //Text styling, how the format should be.
    public enum TextStyle
    {
        StringAtomnameStringGroupString,
        StringAtomnameStringPeriodString,
        StringAtomnameStringAtomnumberString,
        StringAtomnumberStringAtomnameString, 
        StringAtomnameStringAtomgroupStringAtomperiodString
    }

    [SerializeField] [Header("The AI's Task")] Dropdown Tasks;
    [SerializeField] [Header("Dialog")]
    [TextArea(1, 20)]
    public string Request;
    [TextArea(1, 20)]
    public string Success;
    [TextArea(1, 20)]
    public string Failure;

    [SerializeField] [Header("TekstDisplay (Husk MellemRum)")] TextStyle TekstStyle;
    [TextArea(1, 20)]
    public string Hint1Part1;
    [TextArea(1, 20)]
    public string Hint1Part2;
    [TextArea(1, 20)]
    public string Hint1Part3;
    [TextArea(1, 20)]
    public string Hint1Part4;
    [TextArea(1, 20)]
    public string Hint2Part1;
    [TextArea(1, 20)]
    public string Hint2Part2;
    [TextArea(1, 20)]
    public string Hint2Part3;
    [TextArea(1, 20)]
    public string Hint2Part4;

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
    [System.NonSerialized] private int CustommerTask, AtomGroup, AtomNumber, AtomPeriod, Results;
    [System.NonSerialized] public string Hint1, Hint2, AtomName;
    [System.NonSerialized] public AiCustomerManager theAIManagaer;
    [System.NonSerialized] public GameObject ResultManager;
    [System.NonSerialized] public PointSystemScript points;




    //            Code overview
    // 
    // public void Start()
    //        void Update()
    //            Sorting
    // public void textStyleChoice()
    // public void CustommerTaskSet()
    // public void CustommerRecieved()
    //             Functions to Check recieved object
    // public void ReceiveObjectAtomNumber()
    // public void ReceiveObjectAtomMass()
    // public void ReceiveObjectGroup()
    // public void ReceiveObjectPeriod()
    // public void ReceiveObjectGroupeAndPeriod()
    // public void ReceiveObjectFirstShell()
    // public void ReceiveObjectSecondShell()
    // public void ReceiveObjectThirdShell()
    // public void ReceiveObjectFourthShell()
    // public void ReceiveObjectFifthShell()
    // public void ReceiveObjectSixthShell()
    // public void ReceiveObjectSeventhShell()
    // public void ReceiveObjectOuterShell()
    //            Getting sending Changing bool strings etc.
    // public void SetHint1Bool()
    // public void SetFailBoool()
    // public void Correct()
    // public void Wrong()
    // public void SetRequest()


    public void Awake()
    {
        theAIManagaer = FindObjectOfType<AiCustomerManager>();
        playerController = playerC.GetComponent<PlayerController>();
        CustommerTaskSet();
        forTextField.text = this.Request;
        scientistController = GetComponent<ScientistController>();
        points = GameObject.Find("Points").GetComponent<PointSystemScript>();
        Results = 0;
        ResultManager = GameObject.Find("StoringResult");

    }
    // Update is called once per frame
    void Update()
    {
      // print(Tasks);
    }


    /*
     * Her bliver Hint 1 og Hint 2's format lavet, alts� ex. string + atomname + string + atomnumber + string 
     * 
     */
    public void textStyleChoice(GameObject receivedObject)
    {
        AtomName = receivedObject.GetComponent<Atom>().AtomName;
        AtomGroup = receivedObject.GetComponent<Atom>().Group;
        AtomNumber = receivedObject.GetComponent<Atom>().AtomNumber;
        AtomPeriod = receivedObject.GetComponent<Atom>().Period;

        if (TekstStyle == TextStyle.StringAtomnameStringGroupString)
        {
            Hint1 = Hint1Part1 + AtomName + Hint1Part2 + AtomGroup + Hint1Part3;
            Hint2 = Hint2Part1 + AtomName + Hint2Part2 + AtomGroup + Hint2Part3;
        }
        if (TekstStyle == TextStyle.StringAtomnameStringPeriodString)
        {
            Hint1 = Hint1Part1 + AtomName + Hint1Part2 + AtomPeriod + Hint1Part3;
            Hint2 = Hint2Part1 + AtomName + Hint2Part2 + AtomPeriod + Hint2Part3;
        }
        if (TekstStyle == TextStyle.StringAtomnameStringAtomnumberString)
        {
            Hint1 = Hint1Part1  + AtomName + Hint1Part2  + AtomNumber + Hint1Part3;
            Hint2 = Hint2Part1  + AtomName + Hint2Part2  + AtomNumber + Hint2Part3;
        }
        if (TekstStyle == TextStyle.StringAtomnumberStringAtomnameString)
        {
            Hint1 = Hint1Part1 + AtomNumber + Hint1Part2 + AtomName + Hint1Part3;
            Hint2 = Hint2Part1 + AtomNumber + Hint2Part2 + AtomName + Hint2Part3;

        }
        if (TekstStyle == TextStyle.StringAtomnameStringAtomgroupStringAtomperiodString)
        {
            Hint1 = Hint1Part1 + AtomName + Hint1Part2 + AtomGroup + Hint1Part3 + AtomPeriod + Hint1Part4;
            Hint2 = Hint2Part1 + AtomName + Hint2Part2 + AtomGroup + Hint2Part3 + AtomPeriod + Hint2Part4;
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
            playerController.oneAtomTask = true;
        }
        else if (Tasks == Dropdown.Period)
        {
            CustommerTask = 1;
            playerController.oneAtomTask = true;
        }
        else if (Tasks == Dropdown.GroupAndPeriod)
        {
            CustommerTask = 2;
            playerController.oneAtomTask = true;
        }
        else if (Tasks == Dropdown.AkaliMetaler)
        {
            CustommerTask = 3;
            playerController.multipleAtomTask = true;
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
     * Her bliver l�sningen valgt udfra hvad man v�lger Group,Period,GroupAndPeriod ETC.
     * det bliver valgt ud fra int CustommerTask, I drop down Menu er Group = 0 Period = 1 osv.
     * s� fra top til bunden, g�r det fra 0 til 6 (atm)
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
            // public void CustommerRecievedMulti(GameObject[] receivedObject)
            // is used mostly if not it will check
            ReceiveObjectAkaliMetal(receivedObject);
        }
        if (CustommerTask == 4)
        {
            // public void CustommerRecieved(int receivedAtomMass)
            // is used instead
        }
        if (CustommerTask == 5)
        {
            
        }
        if (CustommerTask == 6)
        {
            ReceiveObjectOuterShell(receivedObject);
        }
    }
    public void CustommerRecieved(string receivedAtomMass)
    {
        if (CustommerTask == 5)
        {
            ReceiveObjectAtomMass(receivedAtomMass);
        }
    }

        public void CustommerRecievedMulti(GameObject[] receivedObject)
    {
        if (CustommerTask == 3)
        {
            Akalibool = new bool[receivedObject.Length];
           if(receivedObject.Length != 6)
            {
                Wrong();
            }
            if (receivedObject.Length == 6)
            {
                for (int i = 0; i < receivedObject.Length; i++)
                {
                    if (receivedObject[i].GetComponent<Atom>().CheckIfAkali())
                    {
                        Akalibool[i] = true;
                    }
                    if (!receivedObject[i].GetComponent<Atom>().CheckIfAkali())
                    {
                        Akalibool[i] = false;
                    }
                }
                if (Akalibool.All(b => b))
                {
                    Correct();
                }
                else if (Akalibool.All(b => !b))
                {
                    Wrong();
                }
            }
        }
        
    }


  
    /*
     * Disse Functioner checker om det g�ldende krav er Correct i Atommerne.
     * den tilg�r det object der valgt "receivedObject" og tilg�r dens script 
     * "Atom" i den er der functioner der checker om det er Correct og sender 
     * en bool tilbage der enten er true eller false hvis den er true s� k�re
     * functionen Correct() som er l�ngere oppe i teksten.
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
    public void ReceiveObjectAtomMass(string RecievedString)
    {
        if (RecievedString == RequestedAtomMass.ToString())
        {
            Correct();
        }
        if (RecievedString != RequestedAtomMass.ToString())
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
        else  if(receivedObject.GetComponent<Atom>().CheckGroup(RequestedGroup))
        {
            Wrong();
        }
        else if(!receivedObject.GetComponent<Atom>().CheckPeriod(RequestedPeriod))
        {
            Wrong();
        }
        else
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

    public void ReceiveObjectAkaliMetal(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckIfAkali())
        {
            Correct();
        }
        if (!receivedObject.GetComponent<Atom>().CheckIfAkali())
        {
            Wrong();
            print(receivedObject.GetComponent<Atom>().Shells);
        }
    }
    public bool ReceiveObjectAkaliMetalMulti(GameObject receivedObject)
    {
        if (receivedObject.GetComponent<Atom>().CheckIfAkali())
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    /*
    * 
    * Det her er functionerne der k�rer hvis svaret er 
    * rigtigt - Correct, 
    * eller forkert - Wrong.
    * Hvis svaret er korrekt s� k�re funktionen Correct()
    * Hvis svaret derimod er forkert k�re funktionen Wrong() 
    */
    public void Correct()
    {
        forTextField.text = Success;
        scientistController.correctAnswer = true;
        ResultManager.GetComponent<EndStringPrintout>().AddToResultCode(Results);
        points.PointsAdded(Results);

    }

    public void Wrong()
    {
        if (FailBool)
        {
            Results = 3;
            //leaving and get new ai
            forTextField.text = Failure;
            scientistController.doneWithTask = true;
            ResultManager.GetComponent<EndStringPrintout>().AddToResultCode(Results);
            points.PointsAdded(Results);
            playerController.oneAtomTask = false;
            playerController.multipleAtomTask = false;
        }
        if (Hint2Bool)
        {
            Results = 2;
            Hint2Bool = false;
            FailBool = true;
            forTextField.text = Hint2;
            scientistController.wrongAnswer = true;
        }
        if (Hint1Bool)
        {
            Results = 1;
            Hint1Bool = false;
            Hint2Bool = true;
            forTextField.text = Hint1;
            scientistController.wrongAnswer = true;
        }
    }

    // This function set the text to be the request of the current AICustommer.
    public void setRequest()
    {
        forTextField.text = Request;
    }
}
