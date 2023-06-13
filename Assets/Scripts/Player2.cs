using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

public class Player2 : MonoBehaviour
{
    public int Health;

    private PlayerData _playerData;
    private bool _gameOver;

    void Start()
    {
        _gameOver = false;
        _playerData = new PlayerData
        {
            username = "TestRequest"
        };
        StartCoroutine(Download(result => {
            Debug.Log(result);
        }));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.Health--;
        }
        if (Health <= 0)
        {
            _gameOver = true;
        }
    }

    IEnumerator Download(System.Action<PlayerData> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get("mongodb+srv://admin:VjIPOBWbTGVDwl4V@quackochocolat.bsxbipg.mongodb.net/TowerDefense"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                if (callback != null)
                {
                    callback.Invoke(null);
                }
            }
            else
            {
                if (callback != null)
                {
                    callback.Invoke(PlayerData.Parse(request.downloadHandler.text));
                }
            }
        }
    }

    IEnumerator Upload(string profile, System.Action<bool> callback = null)
    {
        using (UnityWebRequest request = new UnityWebRequest("mongodb+srv://admin:VjIPOBWbTGVDwl4V@quackochocolat.bsxbipg.mongodb.net/TowerDefense", "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(profile);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                if (callback != null)
                {
                    callback.Invoke(false);
                }
            }
            else
            {
                if (callback != null)
                {
                    callback.Invoke(request.downloadHandler.text != "{}");
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (_gameOver)
        {
            StartCoroutine(Upload(_playerData.Stringify(), result => {
                Debug.Log(result);
            }));
            _gameOver = false;
            this.Health = 5;
        }
    }
}
