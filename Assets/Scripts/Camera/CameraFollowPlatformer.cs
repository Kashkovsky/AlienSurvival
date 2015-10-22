using UnityEngine;
using System.Collections;

public class CameraFollowPlatformer : MonoBehaviour {

	public Transform Player;
	public float Distance = 10f;
	public float Height = 10f;

	void Update() {
		transform.position = new Vector3 (Player.position.x, Player.position.y + Height, -Distance);
		transform.LookAt (Player);
	}
}
