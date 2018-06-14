using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedItemPool : MonoBehaviour
{
    public GameObject item;
    public int pooledAmount;

    private int PopedIndexNumber;

    Dictionary<string, GameObject> items;

    private void Update()
    {
        //임시 확인용
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PopItemFromPool();
        }
        //임시 확인용2
        if(Input.GetKeyDown(KeyCode.E))
        {
           PushItemToPool();
        }
    }

    private void Start()
    {
        items = new Dictionary<string , GameObject>();
        GetObjectPool();
    }

    void GetObjectPool()
    {
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject itemObject = Instantiate(item);

            itemObject.SetActive(false);
            items.Add("itemObject" + i, itemObject);
            itemObject.name = "itemObject" + i;
        }
    }
    
    void PopItemFromPool()
    {
        for(int i = 0; i<items.Count; i++)
        {
            if(!items["itemObject" + i].activeInHierarchy)
            {
                items["itemObject" + i].transform.position = transform.position;
                items["itemObject" + i].SetActive(true);
                PopedIndexNumber = i;
                break;
            }
        }
    }

    public void PushItemToPool()
    {
        //****************************************
        //리턴아이템 시킬 때 딕셔너리 키값을 못찾는다는 에러 원인 확인 및 딕셔너리 완성
        for (int i = PopedIndexNumber ; i >= 0; i--)  //이쪽으로 pooledAmount값이 안들어감 // 정확한 값을 찾아서 반환하기 위한 조건.....
        {
            if(items["itemObject" + i].activeInHierarchy)
            { 
            Debug.Log(PopedIndexNumber);
                items["itemObject"+ i].SetActive(false);
                PopedIndexNumber = i ;
                break;
            }
        }
    }

}
