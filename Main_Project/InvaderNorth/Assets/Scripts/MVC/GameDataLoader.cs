﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase;
using System;
using System.Linq;

public enum SignInProcessType
{
    NoAccount,
    WrongPassword,
    Success
}

public class GameDataLoader : MonoBehaviour {

    private GameData userGameData;
    private DatabaseReference reference;

    public delegate void LoadDataCallback(GameData gameData, SignInProcessType loginProcessType);
    public LoadDataCallback loadDataCallback;

    public delegate void CreateAccountCallBack(bool IsCreated);
    public CreateAccountCallBack createAccountCallBack;

    public delegate void RenewDataCallback();
    public RenewDataCallback renewDataCallback;

    public delegate void RenewPurchaseDataCallback();
    public RenewDataCallback renewPurchaseDataCallback;

    private void Start()
    {
        DontDestroyOnLoad(this);

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://invaderspolaris.firebaseio.com");

        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void LoadGameDataFromDB(string id, string password)
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(
        task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("데이터베이스에 접근할 수 없습니다");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot datasnapshot in snapshot.Children)
                {
                    if (id.Equals(datasnapshot.Key))
                    {
                        Dictionary<string, object> userDataDictionary = (Dictionary<string, object>)datasnapshot.Value;
                        if (password.Equals(userDataDictionary.FirstOrDefault(x => x.Value.ToString() == password).Value))
                        {
                            Debug.Log("로그인 데이터 확인 완료");

                            userGameData = new GameData
                            {
                                id = id,
                                password = password,
                                credit = Convert.ToInt32(userDataDictionary["credit"]),
                                hpLevel = Convert.ToInt32(userDataDictionary["hpLevel"]),
                                bulletLevel = Convert.ToInt32(userDataDictionary["bulletLevel"]),
                                critLevel = Convert.ToInt32(userDataDictionary["critLevel"]),
                                highestScore = Convert.ToInt32(userDataDictionary["highestScore"]),
                                totalScore = Convert.ToInt32(userDataDictionary["totalScore"])     
                            };
                            loadDataCallback(userGameData, SignInProcessType.Success);
                            return;
                        }
                        else
                        {
                            Debug.Log("비밀번호가 틀렸습니다");
                            loadDataCallback(null, SignInProcessType.WrongPassword);
                            return;
                        }
                    }
                }
                Debug.Log("회원가입이 되어있지 않습니다");
                loadDataCallback(null, SignInProcessType.NoAccount);
                return;
            }
        });
    }
    public void MakeNewAccountInDB(string id, string password)
    {
        Dictionary<string, object> userDataDictionary = new Dictionary<string, object>
        {
            { "password", password },
            { "credit", 1000 },
            { "hpLevel", 0 },
            { "bulletLevel", 0 },
            { "critLevel", 0 },
            { "highestScore", 0 },
            { "totalScore", 0 }
        };
        userDataDictionary.OrderByDescending(num => num.Key);


        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(
        searchtask =>
        {
            if (searchtask.IsFaulted)
            {
                Debug.Log("데이터베이스에 접근할 수 없습니다");
                return;
            }
            else if (searchtask.IsCompleted)
            {
                DataSnapshot snapshot = searchtask.Result;
                foreach (DataSnapshot datasnapshot in snapshot.Children)
                {
                    if (id.Equals(datasnapshot.Key))
                    {
                        Debug.Log("이미 계정이 존재합니다");
                        createAccountCallBack(false);
                        return;
                    }
                }
                reference.Child("users").Child(id).SetValueAsync(userDataDictionary).ContinueWith(
                signUpTask =>
                {
                    if (signUpTask.IsFaulted)
                    {
                        Debug.Log("데이터베이스에 접근할 수 없습니다");
                        return;
                    }
                    else if (signUpTask.IsCompleted)
                    {
                        Debug.Log("회원가입 성공");
                        createAccountCallBack(true);
                        return;
                    }
                });
                return;
            }
        });
    }

    public void SetNewDataInDB(int credit)
    {
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(
        searchtask =>
        {
            if (searchtask.IsFaulted)
            {
                Debug.Log("데이터베이스에 접근할 수 없습니다");
                return;
            }
            else if (searchtask.IsCompleted)
            {
                string userId = DataManager.Datainstance.gameData.id;
                DataSnapshot snapshot = searchtask.Result;
                foreach(DataSnapshot datasnapshot in snapshot.Children)
                {
                    if (userId.Equals(datasnapshot.Key))
                    {
                        reference.Child("users").Child(userId).Child("credit").SetValueAsync(credit).ContinueWith(
                        renewingTask =>
                        {
                            if (renewingTask.IsFaulted)
                            {
                                Debug.Log("데이터베이스에 접근할 수 없습니다");
                                return;
                            }
                            else if (renewingTask.IsCompleted)
                            {
                                Debug.Log("데이터 갱신 성공");
                                renewDataCallback();
                                return;
                            }
                        });
                    }
                }
            }
        });
    }

    public void SetPurchaseDataInDB(int credit, GameData gameData)
    {
        Dictionary<string, object> purchasePartDictionary = new Dictionary<string, object>
        {
            { "credit", credit },
            { "hpLevel", gameData.hpLevel },
            { "bulletLevel", gameData.bulletLevel },
            { "critLevel", gameData.critLevel },
        };

        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(
        searchtask =>
        {
            if (searchtask.IsFaulted)
            {
                Debug.Log("데이터베이스에 접근할 수 없습니다");
                return;
            }
            else if (searchtask.IsCompleted)
            {
                string userId = DataManager.Datainstance.gameData.id;
                DataSnapshot snapshot = searchtask.Result;
                foreach (DataSnapshot datasnapshot in snapshot.Children)
                {
                    if (userId.Equals(datasnapshot.Key))
                    {
                        reference.Child("users").Child(userId).UpdateChildrenAsync(purchasePartDictionary);
                        Debug.Log("데이터 갱신 성공");
                        renewPurchaseDataCallback();
                        return;
                    }
                }
            }
        });
    }
}


