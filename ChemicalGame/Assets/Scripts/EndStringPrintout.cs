using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EndStringPrintout : MonoBehaviour
{
    public string EndResults;
    public string fileName;
    private float startTime;

    // Start is called before the first frame update
    public void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }
    public void PrintText()
    {
        
        string TestPersonNumber = PlayerPrefs.GetString("TestPersonNumber");
        string fileName = "Testperson "+ TestPersonNumber;
        string fileExtension = ".txt";
        string folderPath = Application.dataPath + "/Results/";
        string filePath = folderPath + "/" + fileName + fileExtension;
        float endTime = Time.realtimeSinceStartup;

        // Calculate the runtime in seconds
        float runtime = endTime - startTime;
        int runtimeMins = Mathf.FloorToInt(runtime/60);
        int runtimeSeconds = Mathf.FloorToInt( runtime % 60);
        Debug.Log("Function runtime: " + runtime + " seconds");
        int fileNumber = 1;
        string TimeToBeat = "\n Time: " + runtimeMins.ToString() + " : " + runtimeSeconds;
        EndResults += TimeToBeat;
        Debug.Log(TimeToBeat);
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

        File.WriteAllText(filePath, EndResults);


    }
    public void AddToResultCode(int results)
    {
        EndResults += results.ToString();
    }
}
