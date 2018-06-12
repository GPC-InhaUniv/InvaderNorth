using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase;
using System;

public enum LoginProcessType
{
    NoAccount,
    WrongPassword,
    Success
}

public class GameDataLoader : MonoBehaviour {

    private GameData userGameData;
    private DatabaseReference reference;

    public delegate void LoadDataCallback(GameData gameData, LoginProcessType loginProcessType);
    public LoadDataCallback loadDataCallback;

    public delegate void CreateAccountCallBack();
    public CreateAccountCallBack createAccountCallBack;

    private void Start()
    {
        DontDestroyOnLoad(this);

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://invaderspolaris.firebaseio.com");

        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void LoadGameDataFromDB(string id, string password)
    {
        Task firebasetask = FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(
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
                        if (password.Equals(datasnapshot.Value.ToString()))
                        {
                            Debug.Log("로그인 데이터 확인 완료");
                            userGameData = new GameData
                            {
                                id = id,
                                password = password
                            };
                            loadDataCallback(userGameData, LoginProcessType.Success);
                            return;
                        }
                        else
                        {
                            Debug.Log("비밀번호가 틀렸습니다");
                            loadDataCallback(null, LoginProcessType.WrongPassword);
                            return;
                        }
                    }
                }
                Debug.Log("회원가입이 되어있지 않습니다");
                loadDataCallback(null, LoginProcessType.NoAccount);
                return;
            }
        });
    }
    public void MakeNewAccountInDB(string id, string password)
    {
        reference.Child("users").Child(id).Child("Password").SetValueAsync(password).ContinueWith(
        task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("데이터베이스에 접근할 수 없습니다");
            }
            else if (task.IsCompleted)
            {
                Debug.Log("회원가입 성공");
                createAccountCallBack();
            }
        });
    }
}


