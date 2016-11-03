#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;


namespace PixelGridSpace
{
	[ExecuteInEditMode]
	public class PixelSnapToGrid : MonoBehaviour {

		void Awake()
		{
			if(Application.isPlaying)
				Destroy(this);
		}



		public void SnapToGrid()
		{	
			SnapParentFirst();
			snapToGrid_ = new SnapToGrid(this.gameObject, GetGrid());
			Undo.RegisterCompleteObjectUndo(this.transform, "Snap");
			snapToGrid_.SnapGameObjectToGrid();
		}



		void SnapParentFirst()
		{
			PixelSnapToGrid[] parents = gameObject.GetComponentsInParent<PixelSnapToGrid>();
			foreach(PixelSnapToGrid parent in parents)
			{
				if(parent != this)
					parent.SnapToGrid();
			}
		}



		PixelGrid GetGrid()
		{
			if(grid == null)
				return PixelGrid.instance;
			else
				return grid;
		}



		#if UNITY_EDITOR
			[MenuItem ("Tools/PixelGrid/Snap Selected %k", false, 1)]
			static void SnapSelected() 
			{
				Selection.activeGameObject.GetComponent<PixelSnapToGrid>().SnapToGrid();
			}
			
			
			
			[MenuItem ("Tools/PixelGrid/Snap Selected %k", true)]
			static bool IsPixelObjectSelected()
			{
				return Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<PixelSnapToGrid>() != null;
			}



			[MenuItem ("Tools/PixelGrid/Snap All %l", false, 2)]
			public static void SnapAllObjectsInScene()
			{
				foreach(PixelSnapToGrid someObject in GameObject.FindObjectsOfType<PixelSnapToGrid>())
				{
					someObject.SnapToGrid();
				}
			}



			[ContextMenu ("Snap To Grid")]
			public void SnapToGrid_Menu()
			{
				SnapToGrid();
			}
			

			
			[ContextMenu ("Snap All")]
			public void SnapAllToGrid_Menu()
			{
				SnapAllObjectsInScene();
			}
		#endif


		public PixelGrid grid;

		private SnapToGrid snapToGrid_;
	}
}

#endif