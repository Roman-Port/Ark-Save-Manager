# Ark-Save-Manager
Open and edit Ark saves in C#. Also provides a super easy API that simplifies reading dinos, their inventory, and their stats.

Takes a lot of inspiration from the amazing work by [Ark-Mod](https://github.com/ark-mod/ArkSavegameToolkitNet).

You can take a look at the official documentation of the .ark file at https://us-central.assets-static-2.romanport.com/ark/

# Ark HTTP Server has been moved
The Ark HTTP folder has been moved to it's own ArkWebMap repo. Get it [here](https://github.com/Roman-Port/Ark-Web-Map).

## What is Included
In this repo, you will find...
* A library to read Ark save files, written in C#
* A library to easily read game data and display classes with easy to read data
* A simple sample program written in WinForms to view Ark data

## What Works
As of the latest commit, the following data can be read:
* .ark file
* Dino and item entries. Also supports calculation of Ark stats.

## Planned Changes Soon
* Get better dino entries
* Begin saving support