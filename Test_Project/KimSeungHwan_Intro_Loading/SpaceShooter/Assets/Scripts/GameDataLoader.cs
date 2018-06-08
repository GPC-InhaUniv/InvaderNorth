using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase;
using System;

public class GameDataLoader : MonoBehaviour {

    private GameData userGameData;

    public delegate void LoadDataCallback(GameData gameData);
    public LoadDataCallback loadDataCallback;

    public void LoadGameDataFromDB(string id, string password)
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://invaderspolaris.firebaseio.com");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        Task firebasetask = FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(
            task =>
            {
                string idQuery = id;
                string pwQuery = password;

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
                            if (password.Equals(datasnapshot.Value.ToString()))
                            {
                                Debug.Log("로그인 데이터 확인 완료");
                                userGameData = new GameData
                                {
                                    id = id,
                                    password = password
                                };
                                loadDataCallback(userGameData);
                                return;
                            }
                            else
                            {
                                Debug.Log("비밀번호가 틀렸습니다");
                                loadDataCallback(null);
                                return;
                            }
                        }
                    }
                    Debug.Log("회원가입이 되어있지 않습니다");
                    loadDataCallback(null);
                    return;
                }
            });
    }
    public void MakeNewAccountInDB()
    {
        //파이어베이스를 통한 새 계좌 
    }
}


