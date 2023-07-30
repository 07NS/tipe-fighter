using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] float constVel = -10f;
    Rigidbody2D rb;
    TextMesh tm;
    string enemyString;
    int lifeLeft;
    MainShip mainShip = MainShip.Instance;
    public LinkedListNode<Enemy> Node;

    private void Awake()
    {
        tm = GetComponentInChildren<TextMesh>();
        enemyString = GetRandomWord();
        lifeLeft = enemyString.Length;
        tm.text = enemyString;
        Debug.Log(enemyString);
        this.Node = mainShip.spawnedEnemies[enemyString[0]-'a'].AddLast(this);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, constVel * Time.deltaTime);
    }

    private string GetRandomWord()
    {
        string word = "";
        var alphabets = new Dictionary<int, char> {
            {1,'a'}, {2,'b'}, {3,'c'}, {4,'d'}, {5,'e'}, {6,'f'}, {7,'g'}, {8,'h'}, {9,'i'}, {10,'j'}, {11,'k'}, {12,'l'},
            {13,'m'}, {14,'n'}, {15,'o'}, {16,'p'}, {17,'q'}, {18,'r'}, {19,'s'}, {20,'t'}, {21,'u'}, {22,'v'}, {23,'w'},
            {24,'x'}, {25,'y'}, {26,'z'}
        };
        int iterations = 0;
        while (iterations<3)//TODO: change to variable
        {
            word+=alphabets[Random.Range(1, 27)];
            iterations++;
        }
        return word;
    }
    public string GetName()
    {
        return enemyString;
    }

    public char GetExposedCharacter()
    {
        return enemyString[^lifeLeft];
    }

    public char Hurt(int dmg=1)
    {
        Debug.Log("Hurt: " + this.enemyString);
        lifeLeft-=dmg;
        if (lifeLeft <= 0)
        {
            StartCoroutine(WaitAndDestroy());
            return ' ';
        }
        return enemyString[^lifeLeft]; //same as enemyString.Length-LifeLeft
    }
    private IEnumerator WaitAndDestroy()
    {
        effect.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
