using UnityEngine;
using System;


namespace PixelGridSpace
{
	public class SnapToGrid
	{
		public SnapToGrid(GameObject objectToSnap, PixelGrid grid)
		{
			objectToSnap_ = objectToSnap;
			grid_ = grid;
		}



		public void SnapGameObjectToGrid()
		{	
			try
			{
				CalculateBottomLeft();
				MoveObjectToVertex(GetClosestVertexToBottomLeft());
			}
			catch(System.NullReferenceException e)
			{
				Debug.LogError("Is there a default pixel grid object in the scene? " + e.Message);
			}
		}
		
		
		
		void CalculateBottomLeft()
		{
			Bounds bounds = GetBounds();
			bottomLeft_ = bounds.center;
			bottomLeft_.x -= bounds.extents.x;
			bottomLeft_.y -= bounds.extents.y;
			bottomLeft_.z = objectToSnap_.transform.position.z;
		}
		
		
		
		Bounds GetBounds()
		{
			if(objectToSnap_.GetComponent<Renderer>() == null)
				return CreateBoundsFromTransform();
			else
				return objectToSnap_.GetComponent<Renderer>().bounds;
		}
		
		
		
		Bounds CreateBoundsFromTransform()
		{
			return new Bounds(objectToSnap_.transform.position, objectToSnap_.transform.lossyScale);
		}
		
		
		
		Vector3 GetClosestVertexToBottomLeft()
		{
			int numberOfRows = Mathf.RoundToInt(bottomLeft_.x / grid_.GridSize.x);
			int numberOfColumns = Mathf.RoundToInt(bottomLeft_.y / grid_.GridSize.y);
			
			return new Vector3(numberOfRows * grid_.GridSize.x, numberOfColumns * grid_.GridSize.y, objectToSnap_.transform.position.z);
		}
		
		
		
		void MoveObjectToVertex(Vector3 vertex)
		{
			Vector3 distanceToMove = vertex - bottomLeft_;
			Vector3 newPosition = objectToSnap_.transform.position + distanceToMove;
			objectToSnap_.transform.position = newPosition;
		}
		


		private Vector3 bottomLeft_ = Vector3.zero;
		private GameObject objectToSnap_ = null;
		private PixelGrid grid_ = null;
	}
}

