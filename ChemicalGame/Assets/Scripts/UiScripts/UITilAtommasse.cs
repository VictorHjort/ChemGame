using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UITilAtommasse : MonoBehaviour
{
    public bool isActive;
    public string Awnser;
    public TMP_InputField FieldInput;
    private AiCustomerManager theAIManagaer;
    // Start is called before the first frame update
    private void Awake()
    {
        FieldInput = GetComponent<TMP_InputField>();
        FieldInput.characterValidation = TMP_InputField.CharacterValidation.Decimal;
        FieldInput.onValidateInput += ValidateNumericInput;
        theAIManagaer = FindObjectOfType<AiCustomerManager>();
    }
    private void Update()
    {
        if (!isActive && IntEntered())
        {
            FieldInput.ActivateInputField();
            isActive = true;
            print("active");
        }
        if (isActive && Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Awnser = FieldInput.text.ToString();
            theAIManagaer.Task(Awnser);
            FieldInput.text = "";
            isActive = false;
            print("sending");
        }
        if (isActive && Input.GetKey(KeyCode.Q))
        {
            print(FieldInput.text);
            FieldInput.text = "";
            isActive = false;
            print("delete");
        }

    }

    public void onValueChanged(string NewCharacter)
    {
        NewCharacter = NewCharacter.Replace(",", ".").Replace('.', '\0');
        FieldInput.text = NewCharacter;
    }
    private char ValidateNumericInput(string text, int charIndex, char addedChar)
    {
        // Allow digits, commas, and periods, and disallow all other characters
        if (char.IsDigit(addedChar) || addedChar == ',' || addedChar == '.')
        {
            // Replace commas with periods to ensure consistency
            if (addedChar == ',')
            {
                addedChar = '.';
            }
            return addedChar;
        }
        else
        {
            return '\0';
        }
    }
    public bool IntEntered()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)|| Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4)|| Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0)|| Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Keypad4)|| Input.GetKeyDown(KeyCode.Keypad5)|| Input.GetKeyDown(KeyCode.Keypad6)|| Input.GetKeyDown(KeyCode.Keypad7)|| Input.GetKeyDown(KeyCode.Keypad8)|| Input.GetKeyDown(KeyCode.Keypad9))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Comma)|| Input.GetKeyDown(KeyCode.Period)|| Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            return true;
        }
        else { return false; }
    }
    
}
/* long version of bool IntEntered
       if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            return true;
        }
       if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Comma)
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftCommand))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            return true;
        }
        else { return false;}
    */


/*
    public void CustommerRecievedString(string AwnserString)
    {
        if (CustommerTask == 5)
        {
            ReceiveStringAtomMass(AwnserString);

        }
    }
    public void ReceiveStringAtomMass(string recievedAwnser)
    {
        string wantedmass = RequestedAtomMass.ToString().replace(",",".");


    }
*/