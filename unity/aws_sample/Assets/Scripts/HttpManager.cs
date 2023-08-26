using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using Newtonsoft.Json;
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

	// http://XXXX:yyyy/sentense/ $B$N(BAPI$B$r<B9T$7(B, response$B$K3JG<$9$k(B
	public IEnumerator GET(string sentence) {
		// API$B$N(BURI $B$ODj?t$H$7$FDj$a$i$l$?(BIP$B%"%I%l%9$J$I$H(B, $B;XDj$5$l$?J8;zNs$G9=@.$9$k(B
		string uri = Constants.API_PREFIX + "/" + sentence;
		// $BLa$jCMMQ$N%j%9%H(B
		List<Dictionary<string, string>> response;

		Debug.Log("-------- GET Request Start --------");
		Debug.Log("URI: " + uri);	

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

			// $B%(%i!<$,H/@8$7$?$H$-(B
            if (request.result == UnityWebRequest.Result.ConnectionError ||
				request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("GET Request Failure");
                Debug.Log(request.error);
				// $B%(%i!<$N$H$-$O6u$GJV$9(B
				response = new List<Dictionary<string, string>>();
            }
			// $BDL?.$G$-$?$H$-(B
            else
            {
				//succeeded = true;
                Debug.Log("GET Request Success");

				// $B<u$1<h$C$?J8;zNs$r3JG<(B
				string resText = request.downloadHandler.text;
                Debug.Log(resText);

				// $BJ8;zNs$rJ,3d$7$F%j%9%H$KG<$a$k(B
				response = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(resText);
            }

			// $B%j%9%H$rJV$9(B
			yield return response;
        }
	}
}
