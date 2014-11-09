using UnityEngine;
using System.Collections;

public class PushMine : Mine {
	public float magnitude = 15;
	public void init(GameObject blowupables, float armTime,float detRad, float blastRad, float mag){
		base.init(blowupables, armTime, detRad, blastRad);
		this.magnitude = mag;
	}
	public override void activate(Splodeable s){
		Vector3 r = s.transform.position - this.transform.position;
		if(r.magnitude > 0)
			s.push(r.normalized * magnitude / r.magnitude);
		else{
			Vector3 pushVector = Quaternion.Euler(0, 0, Random.Range(0,359))*Vector3.right * magnitude;
			s.push (pushVector);
		}
	}
}
