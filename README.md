[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/FrixQn/Test-Task-Softner/blob/main/README.md)
[![ru](https://img.shields.io/badge/lang-ru-yellow.svg)](https://github.com/FrixQn/Test-Task-Softner/blob/main/README.ru-RU.md)

<h1 align="center">Test Task at Softner Company</h1>

# Task Description

You need to explore the AxGridTools framework and implement a mechanic based on it.

# Loot Box Opening (Mini-Slot)

There are 3 images in a vertical row on the screen and 2 buttons – Start and Stop.  
You need to implement infinite downward scrolling of images: some go down, others appear at the top and scroll down again, like a slot machine.  
There is a top mask (object) from which the images fall, and a bottom mask where they disappear (object), or a single inside mask.  
When Start is pressed – scrolling begins and gradually accelerates. Stop can only be pressed after 3 seconds.  
When Stop is pressed – the scroll should stop smoothly (not abruptly) and align the center image in the middle of the row.

# Features

1. Connect FSM; pressing Start or Stop should affect state transitions.
2. Work with buttons using UIButtonDataBind.
3. Buttons must be disabled if pressing them would have no effect.
4. Find and add any visual assets – textures or effects (e.g., from the Asset Store).
5. Test on different horizontal resolutions (configure the Canvas).
6. Implement at least one particle system – can be downloaded from the Asset Store.

## **Important:**

* FSM transitions between states internally; state names are only known inside FSM.
* Buttons send signals to the FSM, and FSM sends signals to the visual part of the game.

## Result
![Example](result.gif)

## Stack:
* **Unity 6**
* **DOTween**
* **AxGridTool**