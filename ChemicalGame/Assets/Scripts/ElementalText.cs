using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementalText : MonoBehaviour
{
    public TMP_Text number;
    public TMP_Text symbol;
    public TMP_Text fullname;
    public TMP_Text weight;
    public TMP_Text s1;
    public TMP_Text s2;
    public TMP_Text s3;
    public TMP_Text s4;
    public TMP_Text s5;
    public TMP_Text s6;
    public TMP_Text s7;
    public Material material;
    public string numberVar;
    public string symbolVar;
    public string nameVar;
    public string weightVar;
    public string s1Var;
    public string s2Var;
    public string s3Var;
    public string s4Var;
    public string s5Var;
    public string s6Var;
    public string s7Var;

    private Renderer renderCube;
    public GameObject cube;


    // Start is called before the first frame update
    void Start()
    {
        number.text = numberVar;
        symbol.text = symbolVar;
        fullname.text = nameVar;
        weight.text = weightVar;
        s1.text = s1Var;
        s2.text = s2Var;
        s3.text = s3Var;
        s4.text = s4Var;
        s5.text = s5Var;
        s6.text = s6Var;
        s7.text = s7Var;

        renderCube = cube.GetComponent<Renderer>();
        renderCube.material = material;
        
    }

  
}
