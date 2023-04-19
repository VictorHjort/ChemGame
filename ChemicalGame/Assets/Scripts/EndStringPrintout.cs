using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EndStringPrintout : MonoBehaviour
{
    public string EndResulst;
    public string fileName;
    // Start is called before the first frame update
    public void Start()
    {
    }
    public void PrintText()
    {
        
        string TestPersonNumber = PlayerPrefs.GetString("TestPersonNumber");
        string fileName = "Testperson "+ TestPersonNumber;
        string fileExtension = ".txt";
        string folderPath = Application.dataPath + "/Results/";
        string filePath = folderPath + "/" + fileName + fileExtension;

        int fileNumber = 1;

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        while(File.Exists(filePath))
        {
            fileName = "ResultText (" + fileNumber.ToString() + ")";
            filePath = folderPath + "/" + fileName + fileExtension;
            fileNumber++;
        }

        File.WriteAllText(filePath, EndResulst);


    }
    public void AddToResultCode(int results)
    {
        EndResulst += results.ToString();
    }
}
