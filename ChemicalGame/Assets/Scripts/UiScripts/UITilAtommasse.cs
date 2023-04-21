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
    // Start is called before the first frame update
    private void Awake()
    {
        FieldInput = GetComponent<TMP_InputField>();
        FieldInput.characterValidation = TMP_InputField.CharacterValidation.Decimal;
        FieldInput.onValidateInput += ValidateNumericInput;
        
        print("hey");
    }
    private void Update()
    {
        if (!isActive && Int())
        {
            isActive = true;
            FieldInput.ActivateInputField();
        }
        if(isActive && Input.GetKeyDown(KeyCode.Return))
        {
            Awnser = FieldInput.text.ToString();
            FieldInput.text = "";
            isActive = false;
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
    public bool Int()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            FieldInput.text = "0";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FieldInput.text = "1";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FieldInput.text = "2";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FieldInput.text = "3";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FieldInput.text = "4";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FieldInput.text = "5";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            FieldInput.text = "6";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            FieldInput.text = "7";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            FieldInput.text = "8";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            FieldInput.text = "9";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            FieldInput.text = "0";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            FieldInput.text = "1";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            FieldInput.text = "2";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            FieldInput.text = "3";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            FieldInput.text = "4";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            FieldInput.text = "5";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            FieldInput.text = "6";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            FieldInput.text = "7";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            FieldInput.text = "8";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            FieldInput.text = "9";
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Comma))
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
        else { return false; }
    }
}
