using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//using MiniJSON;
using PublicContents;

public class HttpManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	// http://XXXX:yyyy/sentense/ のAPIを実行し, 文字列をresponseに格納する
	public IEnumerator GET(string sentence) {
		// APIのURI は定数として定められたIPアドレスなどと, 指定された文字列で構成する
		string uri = Constants.API_PREFIX + "/" + sentence;
		// 戻り値用の文字列
		string response;

		Debug.Log("-------- GET Request Start --------");
		Debug.Log("URI: " + uri);	

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

			// エラーが発生したとき
            if (request.result == UnityWebRequest.Result.ConnectionError ||
				request.result == UnityWebRequest.Result.ProtocolError)
			{
                Debug.Log("GET Request Failure");
                Debug.Log(request.error);
				// エラーのときはERRORと返す
				response = "ERROR: " + request.error;
            }
			// 通信できたとき
            else
            {
                Debug.Log("GET Request Success");

				// 受け取った文字列を格納
				response = request.downloadHandler.text;
                Debug.Log(response);
            }

			// 文字列を返す
			yield return response;
        }
	}
}
