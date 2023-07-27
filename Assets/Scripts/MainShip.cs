using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainShip : MonoBehaviour
{
    InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input = FindObjectOfType<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string text = input.text;
            input.text = "";
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetName().ToUpper()==text.ToUpper())
                {
                    enemy.Destroy();
                }
            }
        }
    }
}
