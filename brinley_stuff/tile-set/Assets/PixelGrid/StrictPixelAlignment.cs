using UnityEngine;
using System.Collections;


namespace PixelGridSpace
{
	public class StrictPixelAlignment : MonoBehaviour {

		void Start()
		{
			if(grid == null && PixelGrid.instance != null)
				grid = PixelGrid.instance;

			snapToGrid_ = new SnapToGrid(this.gameObject, grid);
		}



		void LateUpdate()
		{
			transform.position -= amountSnappedLastFrame_;

			lastPosition_ = transform.position;
			snapToGrid_.SnapGameObjectToGrid();
			amountSnappedLastFrame_ = transform.position - lastPosition_;
		}



		public Vector3 GetActualPosition()
		{
			return lastPosition_;
		}



		public PixelGrid grid = null;

		private Vector3 lastPosition_;
		private Vector3 amountSnappedLastFrame_;

		private SnapToGrid snapToGrid_;
	}
}