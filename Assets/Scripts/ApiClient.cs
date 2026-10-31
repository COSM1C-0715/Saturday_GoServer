using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ApiClient : MonoBehaviour
{
    private const string EndPointItems = "items";

    [SerializeField]
    [Header("サーバー設定")]
    [Tooltip("GoサーバーのエンドポイントURL")]
    private string _url = "http://localhost:8080/";

    [Header("UI")]
    [Tooltip("POSTする名前を入力する欄")]
    [SerializeField]
    private TMP_InputField _nameInput;

    [Tooltip("GETを実行するボタン")]
    [SerializeField]
    private Button _getButton;

    [Tooltip("POSTを実行するボタン")]
    [SerializeField]
    private Button _postButton;

    [Tooltip("通信結果を表示するテキスト")]
    [SerializeField]
    private TMP_Text _resultText;
    StringBuilder _builder = new StringBuilder();

    private void OnClickGet()
    {
        StartCoroutine(GetItems());
    }

    private void OnClickPost()
    {
        StartCoroutine(PostItem());
    }

    public IEnumerator GetItems()
    {
        //本来は+ではなく、string.Format等で連結すべき、あと引数化。
        using (UnityWebRequest request = UnityWebRequest.Get(_url + EndPointItems))
        {
            yield return request.SendWebRequest();
            // リクエストを送信して応答が返ってくるまで待つ。

            if (request.result != UnityWebRequest.Result.Success)
            {
                string msg = $"GET 失敗:{request.error}";
                Debug.LogError(msg);
                SetResultText(msg);
                yield break;
            }

            string json = request.downloadHandler.text;

            string wrapped = string.Format("{{\"items\":{0}}}", json);

            ItemList list = JsonUtility.FromJson<ItemList>(wrapped);

            if (TryMakeSBFromItem(list,"GET",ref _builder))
            {
                SetResultText(_builder.ToString());
            }
        }
    }

    public IEnumerator PostItem()
    {
        if (_nameInput == null)
        {
            SetResultText("{Post} _nameInput is Null.");
            yield break;
        }

        string name = _nameInput.text;

        // name null チェック
        if (string.IsNullOrEmpty(_nameInput.text))
        {
            SetResultText("{Post} _nameInput is Null or Empty.");
            yield break;
        }

        // name 空白チェック
        if (name == " " || name == "　　")//半角&全角
        {
            SetResultText("{Post} _nameInput is Space.");
            yield break;
        }

        string bodyJson = JsonUtility.ToJson(new CreateItemRequest(name));

        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJson);

        using (UnityWebRequest req
            = new UnityWebRequest(_url + EndPointItems, UnityWebRequest.kHttpVerbPOST))
        {
            //POSTの場合は、UploadHandlerRawを使う必要がある。
            req.uploadHandler = new UploadHandlerRaw(bodyRaw);

            req.downloadHandler = new DownloadHandlerBuffer();

            req.SetRequestHeader("Content-Type", "application/json");

            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                string msg = $"POST Failed: {req.error}";

                Debug.LogError(msg);
                SetResultText(msg);
                yield break;
            }

            // 成功時の処理
            string json = req.downloadHandler.text;

            Item item = JsonUtility.FromJson<Item>(json);

            _builder.Clear();
            _builder.AppendLine("[POST] Lists");
            _builder.AppendLine();

            if(TryGetItemData(item,_builder))
            {
                SetResultText(_builder.ToString());
            }
        }
        if(_nameInput != null)
        {
            _nameInput.text = string.Empty;
        }
    }

    private bool TryMakeSBFromItem(ItemList list, string method, ref StringBuilder _builder)
    {
        if(_builder == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(method))
        {
            method = "Unknown";
        }

        _builder.Clear();
        _builder.AppendFormat("[{0}] Lists",method);
        _builder.AppendLine();
        _builder.AppendLine();

        if (list == null
            || list.items == null
            || list.items.Length <= 0)
        {
            _builder.AppendLine("(Data id Empty)");
        }
        else
        {
            foreach (Item item in list.items)
            {
                TryGetItemData(item,_builder);
            }
        }
        return true;
    }

    private bool TryGetItemData(Item item, StringBuilder builder)
    {
        if(item ==null
            || builder == null)
        {
            return false;
        }

        builder.AppendFormat("ID:{0},Name:{1}",item.id,item.name);
        builder.AppendLine();
        return true;
    }

    private void SetResultText(string msg)
    {
        if(_resultText != null)
        {
            _resultText.SetText(msg);
        }
    }
    #region Unity Event
    private void Awake()
    {
        if (_getButton != null)
        {
            _getButton.onClick.AddListener(OnClickGet);
        }
        if (_postButton != null)
        {
            _postButton.onClick.AddListener(OnClickPost);
        }
    }

    private void OnDestroy()
    {
        if (_getButton != null)
        {
            _getButton.onClick.RemoveListener(OnClickGet);
            _getButton.onClick.RemoveAllListeners();
        }
        if (_postButton != null)
        {
            _postButton.onClick.RemoveListener(OnClickPost);
        }
    }
    #endregion
}