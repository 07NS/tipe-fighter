using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainShip : MonoBehaviour
{
    public static MainShip Instance { get; private set; }
    InputField input;
    //Unity uses old .Net version which does not have PriorityQueue Support implement a class yourself
    public LinkedList<Enemy>[] spawnedEnemies = new LinkedList<Enemy>[26];
    bool controllingMainShip = true;

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < spawnedEnemies.Length; i++)
        {
            spawnedEnemies[i] = new LinkedList<Enemy>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            //User might be a god and we might get multiple key presses b/w each frame
            string inputKey = Input.inputString.ToLower();
            if (!string.IsNullOrEmpty(inputKey) && inputKey.Length == 1)
            {
                for(int i=0;i<inputKey.Length;i++)
                {
                    Enemy toHurt = GetEnemyFromList(inputKey[i]);
                    if (toHurt != null)
                    {
                        RemoveEnemyFromList(inputKey[i]);
                        char toPush = toHurt.Hurt();//Do not damage player from here spawn a bullet here which will hurt the player
                        if(toPush != ' ')
                        {
                            toHurt.Node = AddEnemyToList(toHurt, true, toPush);
                        }
                    }
                }
            }
        }
    }

    public LinkedListNode<Enemy> AddEnemyToList(Enemy enemy, bool pushFront, char c)
    {
        LinkedListNode<Enemy> itr;
        if (pushFront)
        {
            itr = spawnedEnemies[c-'a'].AddFirst(enemy);
        } 
        else
        {
            itr = spawnedEnemies[c - 'a'].AddLast(enemy);
        }
        return itr;
    }

    public Enemy GetEnemyFromList(char c)
    {
        int ind = c - 'a';
        if (spawnedEnemies[ind].Count > 0)
            return spawnedEnemies[ind].First.Value;
        return null;
    }

    public void RemoveEnemyFromList(char c)
    {
        int ind = c - 'a';
        if (spawnedEnemies[ind].Count > 0)
            spawnedEnemies[ind].RemoveFirst();
    }

    public void RemoveEnemyFromList(char c, LinkedListNode<Enemy> itr)
    {
        int ind = c - 'a';
        if (spawnedEnemies[ind].Count <= 0) return;
        spawnedEnemies[ind].Remove(itr);
    }
}
