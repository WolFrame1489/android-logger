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
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        i+= 0.5f;
        res = Input.gyro.attitude.eulerAngles.x;
        resvec = new Vector3(i, (res + 200), 1);
        Instantiate(xtochka, resvec, Quaternion.identity);
        res = Input.gyro.attitude.eulerAngles.y;
        resvec = new Vector3(i, (res + 200), 1);
        Instantiate(ytochka, resvec, Quaternion.identity);
        res = Input.gyro.attitude.eulerAngles.z;
        resvec = new Vector3(i, (res + 200), 1);
        Instantiate(ztochka, resvec, Quaternion.identity);

    }
    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.x);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.y);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude.eulerAngles.z);
    }
    }
