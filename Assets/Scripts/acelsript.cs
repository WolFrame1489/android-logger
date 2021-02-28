using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using UnityEngine.SceneManagement;
using System.Text;
using System.IO;
using System;

public class acelsript : MonoBehaviour
{
    private List<string[]> rowData = new List<string[]>();
    string[] rowDataTemp = new string[4];
    public Transform xtochka;
    public Transform ytochka;
    public Transform ztochka;
    public GameObject Button2;
    public GameObject Text2;
    public Vector3 resvec;
    public int k = 0;
    public float i = 150f;
    public float res = 0;
    public float timer = 30;

    // Start is called before the first frame update
    void Start()
    {
        rowDataTemp[0] = "X";
        rowDataTemp[1] = "Y";
        rowDataTemp[2] = "Z";
        rowDataTemp[3] = "T";
        rowData.Add(rowDataTemp);
        Button2.SetActive(false);
        Text2.SetActive(false);
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0f)
        {
            i += 0.5f;
            res = Input.acceleration.x;
            rowDataTemp[0] = "" + res;
            resvec = new Vector3(i, (res*10)+250, 1);
            Instantiate(xtochka, resvec, Quaternion.identity);
            res = Input.acceleration.y;
            rowDataTemp[1] = "" + res;
            resvec = new Vector3(i, (res*10)+200, 1);
            Instantiate(ytochka, resvec, Quaternion.identity);
            res = Input.acceleration.z;
            rowDataTemp[2] = "" + res;
            resvec = new Vector3(i, (res*10)+150, 1);
            Instantiate(ztochka, resvec, Quaternion.identity);
            timer -= Time.deltaTime;
            rowDataTemp[3] = "" + (30 - timer);
            rowData.Add(rowDataTemp);
        }
        else
        {
            k++;
            if (k == 1)
            {
                save();
            }
            Button2.SetActive(true);
            Text2.SetActive(true);
        }
    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        if (timer >= 0f)
        {
            GUILayout.Label("input.gyro.attitude: " + Input.acceleration.x);
            GUILayout.Label("input.gyro.attitude: " + Input.acceleration.y);
            GUILayout.Label("input.gyro.attitude: " + Input.acceleration.z);
            GUILayout.Label("timer: " + ((float)System.Math.Round(timer, 3)));
        }
    }
    public void onclick()
    {
        SceneManager.LoadScene("Menu");
    }
    private string getPath()
    {
        return Application.persistentDataPath + "acel_data.csv";
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