using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using UnityEngine.SceneManagement;

public class acelsript : MonoBehaviour
{
    public Transform xtochka;
    public Transform ytochka;
    public Transform ztochka;
    public GameObject Button2;
    public GameObject Text2;
    public Vector3 resvec;
    public float i = 150f;
    public float res = 0;
    public float timer = 30;

    // Start is called before the first frame update
    void Start()
    {
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
            resvec = new Vector3(i, (res*10)+250, 1);
            Instantiate(xtochka, resvec, Quaternion.identity);
            res = Input.acceleration.y;
            resvec = new Vector3(i, (res*10)+200, 1);
            Instantiate(ytochka, resvec, Quaternion.identity);
            res = Input.acceleration.z;
            resvec = new Vector3(i, (res*10)+150, 1);
            Instantiate(ztochka, resvec, Quaternion.identity);
            timer -= Time.deltaTime;
        }
        else
        {
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
}