using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BlockWithItem : MonoBehaviour
{
    public float RandomRatio = 1;

    public GameObject Item;

    public GameObject[] RandomItem;

    public Vector3 ItemPos = Vector2.up;

    private GameObject intances = null;
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer !=null)
        {
            ItemPos.y += Mathf.Sign(ItemPos.y) * renderer.bounds.size.y / 2;
        }

        foreach (GameObject g in RandomItem)
        {
            g.SetActive(false);
        }
    }

     void OnEnable()
    {
        float r = Random.Range(0f, 1f);
        if (r<RandomRatio)
        {
            AddItem();
        }
    }

     void AddItem()
     {
         if (Item == null)
         {
             if (RandomItem!=null && RandomItem.Length>0)
             {
                 int index = Random.Range(0, RandomItem.Length);
                 Item = RandomItem[index];
             }
         }

         if (Item!=null && intances==null)
         {
             Item.SetActive(false);
             GameObject obj = (GameObject)GameObject.Instantiate(Item);
             obj.transform.SetParent(this.transform);
             obj.transform.position = gameObject.transform.position + ItemPos;
             obj.SetActive(true);
             intances = obj;
         }else if (intances!=null)
         {
             if (RandomItem==null||RandomItem.Length==0)
             {
                 intances.transform.position = gameObject.transform.position + ItemPos;
                 intances.SetActive(true);
             }
             else
             {
                 GameObject.Destroy(intances);
                 int index = Random.Range(0, RandomItem.Length);
                 Item = RandomItem[index];
                 GameObject obj = (GameObject)GameObject.Instantiate(Item);
                 obj.transform.SetParent(this.transform);
                 obj.transform.position = gameObject.transform.position + ItemPos;
                 obj.SetActive(true);
                 intances = obj;
             }
         }
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
