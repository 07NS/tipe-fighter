using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] float constVel = -1f;
    Rigidbody2D rb;
    TextMesh tm;
    string name;

    // Start is called before the first frame update
    private void Awake()
    {
        tm = GetComponentInChildren<TextMesh>();
        name = GetRandomWord();
        tm.text = name;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, constVel);
    }

    private string GetRandomWord()
    {
        string word = "";
        var alphabets = new Dictionary<int, string> {
            {1,"A"}, {2,"B"}, {3,"C"}, {4,"D"}, {5,"E"}, {6,"F"}, {7,"G"}, {8,"H"}, {9,"I"}, {10,"J"}, {11,"K"}, {12,"L"}, {13,"M"}, {14,"N"}, {15,"O"}, {16,"P"}, {17,"Q"}, {18,"R"}, {19,"S"}, {20,"T"}, {21,"U"}, {22,"V"}, {23,"W"}, {24,"X"}, {25,"Y"}, {26,"Z"}
        };
        int iterations = 0;
        while (iterations<4)//TODO: change to variable
        {
            word+=alphabets[Random.Range(1, 27)];
            iterations++;
        }
        return word;
    }
    public string GetName()
    {
        return name;
    }
    public void Destroy()
    {
        StartCoroutine(WaitAndDestroy());
    }
    private IEnumerator WaitAndDestroy()
    {
        effect.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
