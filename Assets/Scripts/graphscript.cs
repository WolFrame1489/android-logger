using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class graphscript : MonoBehaviour
{
    public Transform xtochka;
    public Transform ytochka;
    public Transform ztochka;
    public GameObject pixelholder;
    public Vector3 resvec;
    public float i = 50f;
    public float res = 0;
    public float timer = 30;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0f) 
        {
            i += 0.5f;
            res = Input.gyro.attitude.eulerAngles.x;
            resvec = new Vector3(i, (res + 50), 1);
            Instantiate(xtochka, resvec, Quaternion.identity);
            res = Input.gyro.attitude.eulerAngles.y;
            resvec = new Vector3(i, (res + 50), 1);
            Instantiate(ytochka, resvec, Quaternion.identity);
            res = Input.gyro.attitude.eulerAngles.z;
            resvec = new Vector3(i, (res + 50), 1);
            Instantiate(ztochka, resvec, Quaternion.identity);
            timer -= Time.deltaTime;
        }
    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;
        if (timer >= 0f)
        {
            GUILayout.Label("Orientation: " + Screen.orientation);
            GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.x);
            GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.y);
            GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.z);
            GUILayout.Label("timer: " + ((float)System.Math.Round(timer, 3)));
        }
    }
    }
