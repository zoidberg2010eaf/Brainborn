using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_IOS && !UNITY_EDITOR)
using System.Runtime.InteropServices;
#elif (UNITY_ANDROID && !UNITY_EDITOR)
using Google.Play.Review;
#endif

public class AppReviewManager : MonoBehaviour 
{
	
	#if (UNITY_IOS && !UNITY_EDITOR)
    [DllImport ("__Internal")]
    private static extern void requestReview();
	#endif
	
	public static void Request()
	{
		#if (UNITY_IOS && !UNITY_EDITOR)
		Debug.Log("Trying to request the review window.");
	    requestReview();
		#elif (UNITY_ANDROID && !UNITY_EDITOR)

		// StartCoroutine(AndroidReview());
		var reviewManager = new ReviewManager();

		// start preloading the review prompt in the background
		var playReviewInfoAsyncOperation = reviewManager.RequestReviewFlow();

		// define a callback after the preloading is done
		playReviewInfoAsyncOperation.Completed += playReviewInfoAsync =>
		{
			if (playReviewInfoAsync.Error == ReviewErrorCode.NoError)
			{
				// display the review prompt
				var playReviewInfo = playReviewInfoAsync.GetResult();
				reviewManager.LaunchReviewFlow(playReviewInfo);
			}
			else
			{
				// handle error when loading review prompt
			}
		};
		
		#endif
	}

	
}


