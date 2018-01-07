using UnityEngine;

public class AreaEffectorDebuger : MonoBehaviour {
    public AreaEffector2D areaEffector2D;
	void Update () {
        transform.rotation = Quaternion.Euler(0,0,areaEffector2D.forceAngle);
        }
}
