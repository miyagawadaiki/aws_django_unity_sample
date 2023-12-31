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


	// http://XXXX:yyyy/sentense/ $B$N(BAPI$B$r<B9T$7(B, $BJ8;zNs$r(Bresponse$B$K3JG<$9$k(B
	public IEnumerator GET(string sentence) {
		// API$B$N(BURI $B$ODj?t$H$7$FDj$a$i$l$?(BIP$B%"%I%l%9$J$I$H(B, $B;XDj$5$l$?J8;zNs$G9=@.$9$k(B
		string uri = Constants.API_PREFIX + "/" + sentence;
		// $BLa$jCMMQ$NJ8;zNs(B
		string response;

		Debug.Log("-------- GET Request Start --------");
		Debug.Log("URI: " + uri);	

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
			// ssl$BG'>Z$r$H$j$"$($:L5;k$9$k(B. $B%5!<%P!<$,Bg3X;}$A$K$J$C$F>ZL@=q$b:n$C$?$i$b$&;H$o$J$$!*(B Dont use it unless developing stage!
			request.certificateHandler = new BypassCertificate();

            yield return request.SendWebRequest();

			// $B%(%i!<$,H/@8$7$?$H$-(B
            if (request.result == UnityWebRequest.Result.ConnectionError ||
				request.result == UnityWebRequest.Result.ProtocolError)
			{
                Debug.Log("GET Request Failure");
                Debug.Log(request.error);
				// $B%(%i!<$N$H$-$O(BERROR$B$HJV$9(B
				response = "ERROR: " + request.error;
            }
			// $BDL?.$G$-$?$H$-(B
            else
            {
                Debug.Log("GET Request Success");

				// $B<u$1<h$C$?J8;zNs$r3JG<(B
				response = request.downloadHandler.text;
                Debug.Log(response);
            }

			// $BJ8;zNs$rJV$9(B
			yield return response;
        }
	}
}
