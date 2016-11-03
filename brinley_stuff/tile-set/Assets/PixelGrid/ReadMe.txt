------------
Fast Set-Up
------------

1.) In Unity, select Assets > Import Package > Custom Package...
2.) Import the package (if not already imported)
3.) Drag and drog the PixelGrid prefab onto your scene
4.) Attach PixelSnapToGrid to any object
5.) Select Tools > PixelGrid > Snap Selected Object to snap the object to the grid
6.) For using the grid in runtime simply attach StrictPixelAlignment to any object.



----------
PixelGrid
----------

1.) The grid prefab comes with a mesh. You can use any square texture to display the grid. It must be a mesh
2.) By default the grid is not shown in runtime. To enable it simply toggle "Show In Run"
3.) The grid doesn't need to be displayed
4.) Resizing the grid is done by changing the values on the PixelGrid object and right clicking the script and selecting "Apply Grid Size Change"
5.) You can also apply grid size changes from Tools > PixelGrid > Apply Grid Size Change
6.) You can use multiple PixelGrids in a scene, but one (and only one) must have "IsDefaultGrid" checked.
7.) When a grid is resized all Objects are snapped.



----------------
PixelSnapToGrid
----------------

1.) Works with a mesh, sprite, or no renderer
2.) Objects are snapped to their bottom left.
3.) The bottom left is calculated from the renderer's bounds or the GameObject's scale
4.) You can select the grid that the PixelSnap should use. If none is selected it will use the default grid
5.) The script deletes itself in runtime



-----------------------
Strict Pixel Alignment
-----------------------

1.) Works exactly like PixelSnapToGrid, but in runtime
2.) Forces an object to stay aligned to the grid
3.) It uses a call in LateUpdate to achieve this
4.) You shouldn't have to change any existing physics or code to make it work
5.) It's better to come up with your own solution for keeping objects aligned, but it's here if you want it



----------
Shortcuts
----------
1.) Apply Grid Change, Ctrl-J
2.) Snap Seleted, Ctrl-K
3.) Snap All, Ctrl-L
4.) To change the shortcuts open PixelSnapToGrid.cs and PixelGrid.cs. Search for "%k", "%l", or "%j". Edit as needed. 
5.) Further MenuItem documentation can be found at http://docs.unity3d.com/ScriptReference/MenuItem.html



----------------
Common Problems
----------------

1.) If you are moving a camera in LateUpdate you should change the script execution order so that the camera is executed last. Otherwise StrictPixelAlignment can cause "shakes"
2.) Make sure only one grid is the default grid
3.) Avoid using a prefab for the grid if it will exist in multiple scenes. Unless it will remain the exact same
4.) Don't forget to apply the grid size change. Tools > PixelGrid > Apply Grid Change



-------------
Distribution
-------------

1.) The entire package is open-source. Feel free to modify it as needed.
2.) It would be great to receive a shout-out in a completed project, but it's certainly not required



-------
Author
-------
Tyler Millershaski
millershaski@gmail.com

Please send me any questions or concerns.