using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Atom : MonoBehaviour
{
    public string AtomName, AtomSymbol;
    public float AtomMass;
    public int AtomNumber, FirstShell, SecondShell, ThirdShell, FourthShell, FifthShell, SixthShell, SeventhShell;
    public int Group, Period, Shells;

    //             Code overview
    // 
    //        void Start()
    // public void checkAtomNumber()
    // public void checkShells()
    // public void checkGroup()
    // public void checkPeriod()
    //
    //               Functions
    //
    // public bool CheckMass(float ClickedAtomVariable) 
    // public bool CheckAtomNumber(int ClickedAtomVariable)
    // public bool CheckElectron(int ClickedAtomVariable)
    // public bool CheckFirst(int ClickedAtomVariable)
    // public bool CheckSecond(int ClickedAtomVariable)
    // public bool CheckThird(int ClickedAtomVariable)
    // public bool CheckSecond(int ClickedAtomVariable)
    // public bool CheckFourth(int ClickedAtomVariable)
    // public bool CheckFifth(int ClickedAtomVariable)
    // public bool CheckSixth(int ClickedAtomVariable)
    // public bool CheckSeventh(int ClickedAtomVariable)
    // 
    //                Not Used
    //
    //        void Update()




    // Begining of code

    // Start is called before the first frame update
    // This function is getting all the variables from the gameobject (the script ElementalText)
    // And storing it in variables
    void Start()
    {
        // Getting The Atom Name String from the Object and storing it in the AtomName String

        AtomName = this.gameObject.GetComponent<ElementalText>().nameVar;

        // Getting The Atom Symbol String from the Object and storing it in the AtomSymbol String
        // there is two instances of a symbol variable being empty
        if (this.gameObject.GetComponent<ElementalText>().symbolVar != "")
        {
            AtomSymbol = this.gameObject.GetComponent<ElementalText>().symbolVar;
        }

        // Getting The Atom Mass String from the Object and storing it in a float AtomMass
        if (this.gameObject.GetComponent<ElementalText>().weightVar != "") 
        { 
        AtomMass = float.Parse(this.gameObject.GetComponent<ElementalText>().weightVar);
        }


        // Checking the Atom Number (numbervar) to pick two out the ones with more than an int ( containing space and - )
        checkAtomNumber();

        // Checking the 7 shells s2var,.3.4..s8var from the game object and if there is an actual input, and not empty
        // the data gets stored in the ints: SecondShell, ThirdShell, FourthShell, FifthShell, SixthShell, SeventhShell.
        // The 1st shell, s1var from the game object is stored in the int FirstShell
        // (There is always a 1st shell, so it is never empty)
        // Check function for alittle more information
        checkShells();

        // Sorting the atom into Periods depending on the Atom Number´, which is in the AtomNumber Int
        // Check function for alittle more information
        checkPeriod();

        // Sorting the atom into groups depending on the Atom Number´, which is in the AtomNumber Int
        // Check function for alittle more information
        checkGroup();

        /*
         * testing 
         * print(FirstShell + " " + SecondShell + " " + ThirdShell + " " + FourthShell + " " + FifthShell + " " + SixthShell + " " + SeventhShell);
        */
    }

    // Getting The Atom Number String from the Object and storing it in a int AtomNumber
    public void checkAtomNumber()
    {
        // Getting The Atom Number String from the Object and storing it in a int AtomNumber
        // there is two instances of a number variable being something else than a int "89 - 103" and "57 -  71"
        // thats why there is a if statement here
        if (this.gameObject.GetComponent<ElementalText>().numberVar != "89 - 103" && this.gameObject.GetComponent<ElementalText>().numberVar != "57 - 71")
        {
            AtomNumber = int.Parse(this.gameObject.GetComponent<ElementalText>().numberVar);
        }
        if (this.gameObject.GetComponent<ElementalText>().numberVar == "89 - 103")
        {
            AtomName = this.gameObject.GetComponent<ElementalText>().numberVar + " " + this.gameObject.GetComponent<ElementalText>().nameVar;
            AtomNumber = 89;
        }
        if (this.gameObject.GetComponent<ElementalText>().numberVar == "57 - 71")
        {
            AtomName = this.gameObject.GetComponent<ElementalText>().numberVar + " " + this.gameObject.GetComponent<ElementalText>().nameVar;
            AtomNumber = 57;
        }
    }

    // The function is getting each shell variable from the gameobject and storing them in ints
    // First it checks if there is a string input or the string is empty
    // if the string isnot "" the string gets converted into a int and stored.
    public void checkShells()
    {
        // storing s1var from the object (or actually the ElementalTextScript) 
        // Into int FirstShell
        if (this.gameObject.GetComponent<ElementalText>().s2Var != "")
        {
            FirstShell = int.Parse(this.gameObject.GetComponent<ElementalText>().s1Var);
            Shells = 1;
        }
        // Checking if something is in the input for the second shell (the text variable s2 var)
        // If there is an input (not "") the string is converted to a int and stored in int SecondShell
        if (this.gameObject.GetComponent<ElementalText>().s2Var != "")
        {
            SecondShell = int.Parse(this.gameObject.GetComponent<ElementalText>().s2Var);
            Shells = 2;
        }

        // Checking if something is in the input for the thrid shell (the text variable s3 var)
        // If there is an input (not "") the string is converted to a int and stored in int ThirdShell
        if (this.gameObject.GetComponent<ElementalText>().s3Var != "")
        {
            ThirdShell = int.Parse(this.gameObject.GetComponent<ElementalText>().s3Var);
            Shells = 3;
        }

        // Checking if something is in the input for the fourth shell (the text variable s4 var)
        // If there is an input (not "") the string is converted to a int and stored in int FourthShell
        if (this.gameObject.GetComponent<ElementalText>().s4Var != "")
        {
            FourthShell = int.Parse(this.gameObject.GetComponent<ElementalText>().s4Var);
            Shells = 4;
        }

        // Checking if something is in the input for the fifth shell (the text variable s5 var)
        // If there is an input (not "") the string is converted to a int and stored in int FifthShell
        if (this.gameObject.GetComponent<ElementalText>().s5Var != "")
        {
            FifthShell = int.Parse(this.gameObject.GetComponent<ElementalText>().s5Var);
            Shells = 5;
        }

        // Checking if something is in the input for the sixth shell (the text variable s6 var)
        // If there is an input (not "") the string is converted to a int and stored in int SixthShell
        if (this.gameObject.GetComponent<ElementalText>().s6Var != "")
        {
            SixthShell = int.Parse(this.gameObject.GetComponent<ElementalText>().s6Var);
            Shells = 6;
        }

        // Checking if something is in the input for the seventh shell (the text variable s7 var)
        // If there is an input (not "") the string is converted to a int and stored in int SeventhShell
        if (this.gameObject.GetComponent<ElementalText>().s7Var != "")
        {
            SeventhShell = int.Parse(this.gameObject.GetComponent<ElementalText>().s7Var);
            Shells = 7;
        }
    }

    // This funcion is Checking what group the atom number (AtomNumber) belongs to.
    // it consists of if statements and hardcoded numbers, this is because there is no real corrolation
    // numericly so i found it easier to hardcode the variable then to place each number in a varibale. 
    // to use. Then the the object's Group Int is changed to the corrosponding group
    public void checkGroup()
    {

        // If the Atom number is 1, 3, 11,19,37,55 or 87 it is set into group 1
        // These are the atoms that belong to group 1
        // These Objects' Group variable is = 1
        // the Atom number is stored in the AtomNumber int, and is used in the if statements.
        if (AtomNumber == 1 || AtomNumber == 3 || AtomNumber == 11 || AtomNumber == 19 || AtomNumber == 37 || AtomNumber == 55 || AtomNumber == 87)
        {
            Group = 1;
        }

        // Does the same as the above if statement
        // if the Atom number belongings to Group 2
        // these group int is set to 2
        if (AtomNumber == 4 || AtomNumber == 12 || AtomNumber == 20 || AtomNumber == 38 || AtomNumber == 56 || AtomNumber == 88)
        {
            Group = 2;
        }

        // Same as before but for Group 3. Check Group 1 for more information
        if (AtomNumber == 21 || AtomNumber == 39)
        {
            Group = 3;
        }

        // Same as before but for Group 4. Check Group 1 for more information
        if (AtomNumber == 22 || AtomNumber == 40 || AtomNumber == 72 || AtomNumber == 104)
        {
            Group = 4;
        }

        // Same as before but for Group 5. Check Group 1 for more information
        if (AtomNumber == 23 || AtomNumber == 41 || AtomNumber == 73 || AtomNumber == 105)
        {
            Group = 5;
        }

        // Same as before but for Group 6. Check Group 1 for more information
        if (AtomNumber == 24 || AtomNumber == 42 || AtomNumber == 74 || AtomNumber == 106)
        {
            Group = 6;
        }

        // Same as before but for Group 7. Check Group 1 for more information
        if (AtomNumber == 25 || AtomNumber == 43 || AtomNumber == 75 || AtomNumber == 107)
        {
            Group = 7;
        }

        // Same as before but for Group 8. Check Group 1 for more information
        if (AtomNumber == 26 || AtomNumber == 44 || AtomNumber == 76 || AtomNumber == 108)
        {
            Group = 8;
        }

        // You get the drift... 
        // Same as before but for Group 9. Check Group 1 for more information
        if (AtomNumber == 27 || AtomNumber == 45 || AtomNumber == 77 || AtomNumber == 109)
        {
            Group = 9;
        }

        // Same as before but for Group 10. Check Group 1 for more information
        if (AtomNumber == 28 || AtomNumber == 46 || AtomNumber == 78 || AtomNumber == 110)
        {
            Group = 10;
        }

        // Same as before but for Group 11. Check Group 1 for more information
        if (AtomNumber == 29 || AtomNumber == 47 || AtomNumber == 79 || AtomNumber == 111)
        {
            Group = 11;
        }

        // Same as before but for Group 12. Check Group 1 for more information
        if (AtomNumber == 30 || AtomNumber == 48 || AtomNumber == 80 || AtomNumber == 112)
        {
            Group = 12;
        }

        // Same as before but for Group 13. Check Group 1 for more information
        if (AtomNumber == 5 || AtomNumber == 13 || AtomNumber == 31 || AtomNumber == 49 || AtomNumber == 81 || AtomNumber == 113)
        {
            Group = 13;
        }

        // Same as before but for Group 14. Check Group 1 for more information
        if (AtomNumber == 6 || AtomNumber == 14 || AtomNumber == 32 || AtomNumber == 50 || AtomNumber == 82 || AtomNumber == 114)
        {
            Group = 14;
        }

        // Same as before but for Group 15. Check Group 1 for more information
        if (AtomNumber == 7 || AtomNumber == 15 || AtomNumber == 33 || AtomNumber == 51 || AtomNumber == 83 || AtomNumber == 115)
        {
            Group = 15;
        }

        // Same as before but for Group 16. Check Group 1 for more information
        if (AtomNumber == 8 || AtomNumber == 16 || AtomNumber == 34 || AtomNumber == 52 || AtomNumber == 84 || AtomNumber == 116)
        {
            Group = 16;
        }
        // Same as before but for group 17. Check Group 1 for more information
        if (AtomNumber == 9 || AtomNumber == 17 || AtomNumber == 35 || AtomNumber == 53 || AtomNumber == 85 || AtomNumber == 117)
        {
            Group = 17;
        }
        // Same as before but for group 18. Check Group 1 for more information
        if (AtomNumber == 2 || AtomNumber == 10 || AtomNumber == 18 || AtomNumber == 36 || AtomNumber == 54 || AtomNumber == 86 || AtomNumber == 118)
        {
            Group = 18;
        }
    }

    public void checkPeriod()
    {   // If the Atom number is between 1 and 2 its period is set to 1
        // These are the atoms that belong to period 1
        // These Objects Period variable is = 1
        if (AtomNumber >= 1 && AtomNumber <= 2)
        {
            Period = 1;
        }

        // If the Atom number is between 3 and 10 its period is set to 2
        // These are the atoms that belong to period 2
        // these Period variable is = 2
        if (AtomNumber >= 3 && AtomNumber <= 10)
        {
            Period = 2;
        }

        // If the Atom number is between 11 and 18 its period is set to 3
        // These are the atoms that belong to period 3
        // these Period variable is = 3
        if (AtomNumber >= 11 && AtomNumber <= 18)
        {
            Period = 3;
        }

        // The same as before with period 4
        if (AtomNumber >= 19 && AtomNumber <= 36)
        {
            Period = 4;
        }

        // The same as before with period 5
        if (AtomNumber >= 37 && AtomNumber <= 54)
        {
            Period = 5;
        }

        // The same as before with period 6
        if (AtomNumber >= 55 && AtomNumber <= 86)
        {
            Period = 6;

        }

        // The same as before with period 7
        if (AtomNumber >= 87 && AtomNumber <= 118)
        {
            Period = 7;
        }
    }


    // Functions to use in the game using eg.
    // CheckAtomNumber(23)
    // The function in question does
    //
    // if 23 = AtomNumber 
    // return true
    //
    // if 23 != AtomNumber
    // return false
    public bool CheckMass(float ClickedAtomVariable)
    {
        return ClickedAtomVariable == AtomMass;

    }
    public bool CheckAtomNumber(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == AtomNumber;
    }
    public bool CheckElectron(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == AtomNumber;
    }
    public bool CheckFirst(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == FirstShell;
    }
    public bool CheckSecond(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == SecondShell;
    }
    public bool CheckThird(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == ThirdShell;
    }
    public bool CheckFourth(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == FourthShell;
    }
    public bool CheckFifth(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == FifthShell;

    }
    public bool CheckSixth(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == SixthShell;
    }
    public bool CheckSeventh(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == SeventhShell;
    }
    public bool CheckOuterShell(int ClickedAtomVariable, int OuterShell)
    {
        if (OuterShell == 7)
        {
            return ClickedAtomVariable == SeventhShell;
        }
        else if (OuterShell == 6)
        {
            return ClickedAtomVariable == SixthShell;
        }
        else if (OuterShell == 5)
        {
            return ClickedAtomVariable == FifthShell;
        }
        else if (OuterShell == 4)
        {
            return ClickedAtomVariable == FourthShell;
        }
        else if (OuterShell == 3)
        {
            return ClickedAtomVariable == ThirdShell;
        }
        else if (OuterShell == 2)
        {
            return ClickedAtomVariable == SecondShell;
        }
        else if (OuterShell == 1)
        {
            return ClickedAtomVariable == FirstShell;
        }
        else 
        { 
            return false; 
        }

    }
    public bool CheckGroup(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == Group;
    }
    public bool CheckPeriod(int ClickedAtomVariable)
    {
        return ClickedAtomVariable == Period;
    }
    
    
    // Update is called once per frame
    // Is not being used

    void Update()
    {

    }

}
