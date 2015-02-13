using UnityEngine;
using System.Collections;
/*
 * An abstract class for things that can be sploded.
 * Anything that we want to explode should extend this class.
 */
public abstract class Splodeable : MonoBehaviour {
	public abstract void explode();
	public abstract void slow();
	public abstract void push(Vector3 push);
	public abstract void blind(float t);
}
 
