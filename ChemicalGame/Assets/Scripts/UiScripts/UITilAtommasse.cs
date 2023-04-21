using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UITilAtommasse : MonoBehaviour
{
    public bool isActive;
    public TMP_InputField FieldInput;
    // Start is called before the first frame update
    private void Awake()
    {
        FieldInput = GetComponent<TMP_InputField>();
        FieldInput.characterValidation = TMP_InputField.CharacterValidation.Decimal;
        print("hey");
    }
    private void Update()
    {
        if (!isActive && Input.GetKeyDown(KeyCode.Return))
        {
            isActive = true;
            FieldInput.ActivateInputField();
        }
    }

    public void onValueChanged(string NewCharacter)
    {
        NewCharacter = NewCharacter.Replace(",", ".");
        FieldInput.text = NewCharacter;
    }

}
