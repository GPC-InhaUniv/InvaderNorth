using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    bomb,
    shield,
    magnetic,
    darkResource,
}

public class UsedItemPool : MonoBehaviour
{
    public GameObject item;
    public int PooledAmount;
   
    public int PopIndexNumber;
   
    Dictionary<string, GameObject> items;


    private void Start()
    {
        items = new Dictionary<string, GameObject>();
        GetObjectPool();
    }

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
    
    void GetObjectPool()
    {
        for (int i = 0; i < PooledAmount; i++)
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
                PopIndexNumber = i;
                break;
            }
        }
    }

    public void PushItemToPool()
    {
        //****************************************
        //리턴아이템 시킬 때 딕셔너리 키값을 못찾는다는 에러 원인 확인 및 딕셔너리 완성
        for (int i = PopIndexNumber; i >= 0; i--)  //이쪽으로 pooledAmount값이 안들어감 // 정확한 값을 찾아서 반환하기 위한 조건.....
        {
            if(items["itemObject" + i].activeInHierarchy)
            { 
                items["itemObject"+ i].SetActive(false);
                Debug.Log("다시 들어간 오브젝트 번호: " + PopIndexNumber);
                PopIndexNumber--;
                break;
            }
        }
    }
}
