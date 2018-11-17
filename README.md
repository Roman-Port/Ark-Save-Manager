# Ark-Save-Manager
Open and edit Ark saves in C#. Takes a lot of inspiration from the amazing work by [Ark-Mod](https://github.com/ark-mod/ArkSavegameToolkitNet).

You can take a look at the official documentation so far at https://us-central.assets-static-2.romanport.com/ark/

## What Works
As of the latest commit, the following data can be read:
* .Ark Header
* .Ark GameObject bases
* .Ark GameObject props (with the exception of arrays)
* .Ark Visual Viewer (just some WinForms test)

## Planned Changes Soon
* Create .Ark GameObject array prop to fully read in the file
* Begin saving support
* Work on a "high level" access mode so anyone can easily view the game files