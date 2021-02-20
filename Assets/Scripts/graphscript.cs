using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class graphscript : MonoBehaviour
{
    public Transform tochka;
    public GameObject pixelholder;
    public Vector3 resvec;
    public float i = 0;
    public float res = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i+= 0.5f;
        res = Mathf.Cos(i);
        resvec = new Vector3(i, res + 200, 1);
        Instantiate(tochka, resvec, Quaternion.identity);

    }
}
