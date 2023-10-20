using UnityEngine;

    public class Camera2DFollow : MonoBehaviour
    {
		public bool up;
		public bool down;
		public bool SideR;
		public bool SideL;
		public float EndLvlCamSpeed = 0.05f;

		public bool isEdndLvl;
		public float cameraSize = 16;
		private float StartcameraSize;
		private Camera camera;
		public Animator anim;

        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float offsetZ;
        private Vector3 lastTargetPosition;
        private Vector3 currentVelocity;
        private Vector3 lookAheadPos;

		private bool Nitro_camera = false;
		public float Nitro_cameraZOOMOUT = 8;

        // Use this for initialization
        private void Start()
        {

		Screen.SetResolution (1024, 600, true);
            lastTargetPosition = target.position;
            offsetZ = (transform.position - target.position).z;
            transform.parent = null;
			
			StartcameraSize = cameraSize;
			
			camera = GetComponent<Camera> ();
        }

        // Update is called once per frame
        private void Update()
        {

		if (isEdndLvl == true)
		{
			if(up == true)
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y  + EndLvlCamSpeed, transform.position.z) ;
			}

			if(down == true)
			{
				transform.position = new Vector3 (transform.position.x, transform.position.y  - EndLvlCamSpeed, transform.position.z) ;
			}

			if(SideR == true)
			{
				transform.position = new Vector3 (transform.position.x + EndLvlCamSpeed, transform.position.y, transform.position.z) ;
			}

			if(SideL == true)
			{
				transform.position = new Vector3 (transform.position.x - EndLvlCamSpeed, transform.position.y, transform.position.z) ;
			}
		}

		camera.orthographicSize = cameraSize;

		if (Nitro_camera == true && cameraSize < Nitro_cameraZOOMOUT) 
		{
			cameraSize += 1 * Time.deltaTime;
		}

		if (cameraSize < StartcameraSize ) 
		{
			cameraSize += 2 * Time.deltaTime;
		}

		if (cameraSize > StartcameraSize && Nitro_camera == false ) 
		{
			cameraSize -= 1 * Time.deltaTime;
		}

		if (target != null && isEdndLvl == false) 
			{
				// only update lookahead pos if accelerating or changed direction
				float xMoveDelta = (target.position - lastTargetPosition).x;

				bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;

				if (updateLookAheadTarget) {
					lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
				} else {
					lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
				}
				Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
				Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);

				transform.position = newPos;
				lastTargetPosition = target.position;
			}
        }

		void resetCamera() 
		{
		if (Nitro_camera == false && cameraSize < 7.1 && cameraSize > 6.9) 
		{
			cameraSize = StartcameraSize;
		}
		}
		public void damageCamera()
		{
			cameraSize -= 0.25f;
			anim.SetTrigger ("Dmg");
			Invoke ("resetCamera", 0.5f);
		}

		public void nitroCamera()
		{
			Nitro_camera = true;
		}

		public void nitroCameraOFF()
		{
			Nitro_camera = false;
			Invoke ("resetCamera", 1f);
		}
    }

