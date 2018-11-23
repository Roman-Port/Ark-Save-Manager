# Ark-Save-Manager
Open and edit Ark saves in C#. Takes a lot of inspiration from the amazing work by [Ark-Mod](https://github.com/ark-mod/ArkSavegameToolkitNet).

You can take a look at the official documentation so far at https://us-central.assets-static-2.romanport.com/ark/

## What is Included
In this repo, you will find...
* A library to read Ark save files, written in C#
* A library to easily read game data and display classes with easy to read data
* A simple sample program written in WinForms to view Ark data
* A simple HTTP server to request Ark tames from a web browser
* A program to update the local class data from the Ark wiki

## What Works
As of the latest commit, the following data can be read:
* .Ark Header
* .Ark GameObject bases
* .Ark GameObject props (with the exception of arrays)
* .Ark Visual Viewer (just some WinForms test)

## Planned Changes Soon
* Create .Ark GameObject array prop to fully read in the file
* Begin saving support