using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
using System;

public class graphscript : MonoBehaviour
{
    private List<string[]> rowData = new List<string[]>();
    string[] rowDataTemp = new string[3];
    public Transform xtochka;
    public Transform ytochka;
    public Transform ztochka;
    public GameObject pixelholder;
    public GameObject Button;
    public GameObject Text1;
    public Vector3 resvec;
    public float i = 50f;
    public int k = 0;
    public float res = 0;
    public float timer = 30;

    // Start is called before the first frame update
    void Start()
    {
        
        rowDataTemp[0] = "X";
        rowDataTemp[1] = "Y";
        rowDataTemp[2] = "Z";
        rowData.Add(rowDataTemp);
        Button.SetActive(false);
        Text1.SetActive(false);
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0f)
        {
            i += 0.5f;
            rowDataTemp = new string[3];
            res = Input.gyro.attitude.eulerAngles.x;
            rowDataTemp[0] = "" + res;
            resvec = new Vector3(i, (res + 25), 1);
            Instantiate(xtochka, resvec, Quaternion.identity);
            res = Input.gyro.attitude.eulerAngles.y;
            rowDataTemp[1] = "" + res;
            resvec = new Vector3(i, (res + 25), 1);
            Instantiate(ytochka, resvec, Quaternion.identity);
            res = Input.gyro.attitude.eulerAngles.z;
            rowDataTemp[2] = "" + res;
            resvec = new Vector3(i, (res + 25), 1);
            Instantiate(ztochka, resvec, Quaternion.identity);
            timer -= Time.deltaTime;
            rowData.Add(rowDataTemp);
        }
        else
        {
            k++;
            if (k == 1)
            {
                save();
            }
            Button.SetActive(true);
            Text1.SetActive(true);
        }
    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        if (timer >= 0f)
        {
            GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.x);
            GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.y);
            GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.z);
            GUILayout.Label("timer: " + ((float)System.Math.Round(timer, 3)));
        }
    }
    public void onclick()
    {
        SceneManager.LoadScene("Menu");
    }
    private string getPath()
    {
        return Application.persistentDataPath + "gyro_data.csv";
    }
    private string getPathscreen()
    {
        return Application.persistentDataPath + "screen1488228.png";
    }
    public void save()
    {
        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ";";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }
}
