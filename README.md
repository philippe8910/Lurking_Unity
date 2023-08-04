# Lurking_Unity
Inspired by the game "Lurking," I spent some time creating the effects and applying them to VR. The result may not compare to the original game, but I have a prototype now. I plan to develop this concept into a VR game.

## Gameplay
The gameplay is also entirely in darkness for the player. When the player or objects collide, they emit sound waves. These sound waves illuminate nearby objects to provide visibility for the player.
![image](https://github.com/philippe8910/Lurking_Unity/blob/main/Assets/Readme/1.gif)
![image](https://github.com/philippe8910/Lurking_Unity/blob/main/Assets/Readme/2.gif)

## Some problem
Outline shader is not perfact in this project, It can not use in muti material model.  
Outline shader unable to select overlapping objects.  
Sound wave is trigger by trigger enter method, I think its not a good solution to the problem.  

## Use of Assets
Room Model : https://sketchfab.com/3d-models/empty-apartment-0a903c933f8a4e56936ecd8268796fb8#download  
Outline : https://assetstore.unity.com/packages/tools/particles-effects/quick-outline-115488  
Sound Wave Shader : https://assetstore.unity.com/packages/vfx/shaders/special-fx-shaders-49104
