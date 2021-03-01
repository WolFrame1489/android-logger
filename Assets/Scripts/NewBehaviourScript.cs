using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick1()
    {
        Destroy(menu.gameObject);
        SceneManager.LoadScene("Work");
    }
    public void OnClick2()
    {
        Destroy(menu.gameObject);
        SceneManager.LoadScene("Work2");
    }
}
