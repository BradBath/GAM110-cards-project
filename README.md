# GAM110-cards-project

## File structure

The file structure for the game project should be kept as such:

Assets/Resources should only contain assets/subfolders that need to be loaded via Resources.Load

Assets/Scripts should only contain scripts and should have subfolders for each type of script (enums, abstract classes, interfaces) 
and should be namespaced correctly (eg: a script just containing an enum should have the namespace Game.Enum, along with any other enums. Abstract classes would be Game.Abstract). 

Scenes is obvious, it should only contain scenes

Settings should contain only stuff such as the profile for the post-processing 


These rules are so we can keep a clean project and know where everything is/should be.

## Other rules

If you think your code is complex and hard to understand for other programmers, please comment it appropriately.




If you can think of any other rules that can help on this project, post it in the discord.
