using UnityEngine;
using System.Collections.Generic;


#if UNITY_EDITOR
	using UnityEditor;
#endif


namespace PixelGridSpace
{
	#if UNITY_EDITOR
		[ExecuteInEditMode]
	#endif

	public class PixelGrid : MonoBehaviour 
	{
		public static PixelGrid instance;

		void Awake()
		{
			if(isDefaultGrid)
				instance = this;
			textureScale_ = new Vector2(gridGameObjectSizeMultiplier_, gridGameObjectSizeMultiplier_);
		}



		void Start()
		{
			ForceGridSizeFromScale();

			if(ShouldHideGrid())
				DestroyGridDisplay();
			else
				DisplayGrid();
		}
				
		
		
		void ForceGridSizeFromScale()
		{
			GridSize = transform.localScale / (2 * gridGameObjectSizeMultiplier_);
		}



		bool ShouldHideGrid()
		{
			if(showInRun)
				return false;
			return Application.isPlaying;
		}



		void DestroyGridDisplay()
		{	
			transform.localScale = Vector2.zero;
			if(GetComponent<Renderer>() != null)
				this.GetComponent<Renderer>().enabled = false;
		}



		void DisplayGrid()
		{
			transform.position = new Vector3(0,0,transform.position.z) ;
			transform.localScale = GridSize * 2 * gridGameObjectSizeMultiplier_;

			if(GetComponent<Renderer>() != null && GetComponent<Renderer>().sharedMaterial != null)
				GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", textureScale_);
		}



		void Update()
		{				
			ForceDefaultGrid();
		}



		void ForceDefaultGrid()
		{
			if(isDefaultGrid || instance == null)
				instance = this;
		}




		#if UNITY_EDITOR
			[ContextMenu ("Apply Grid Size Change")]
			public void ChangeGridSize()
			{	
				#if UNITY_EDITOR
					Undo.RecordObject(transform, "Change Pixel Grid Size");
				#endif

				PixelSnapToGrid.SnapAllObjectsInScene();
				DisplayGrid();
			}


			
			[MenuItem ("Tools/PixelGrid/Apply Grid Change %j", false, 0)]
			static void ChangeGridSize_Menu() 
			{
				Selection.activeGameObject.GetComponent<PixelGrid>().ChangeGridSize();
			}
			
			
			
			[MenuItem ("Tools/PixelGrid/Apply Grid Change %j", true)]
			static bool IsPixelGridSelected()
			{
				return Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<PixelGrid>() != null;
			}
		#endif





		public bool isDefaultGrid = false;
		public Vector2 GridSize = new Vector2(100,100);
		public bool showInRun = false;


		private const float gridGameObjectSizeMultiplier_ = 10000f;
		private Vector2 textureScale_;
	}
}