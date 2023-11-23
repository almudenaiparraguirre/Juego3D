using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
	[SerializeField] float MouseSpeed = 3;
	[SerializeField] float orbitDamping = 10;
	Vector3 localRot;

    // Start is called before the first frame update
    void Start()
    {
		
    }
	
	void Update()
	{
		transform.position = Player.position;
		
		localRot.x += Input.GetAxis("Mouse X") * MouseSpeed;
		localRot.y -= Input.GetAxis("Mouse Y") * MouseSpeed;
		
		localRot.y = Mathf.Clamp(localRot.y, 0f, 80f);
		
		Quaternion QT = Quaternion.Euler(localRot.y, localRot.x, 0f);
		transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
	}
}
