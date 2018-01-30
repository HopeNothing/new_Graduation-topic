using UnityEngine;

public class DestroyItself : MonoBehaviour {

    [Header("生命週期")]
    public float lifeInSeconds;
	
	void Update () {
        lifeInSeconds -= Time.deltaTime;
        if ( lifeInSeconds<0 )
            {
            Destroy ( gameObject );
            }
	}
}
