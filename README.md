# Quick Timer
Simple and easy to use timer systemfor the Unity engine.

## How To Use
Go to the Unity Package Manager. Cick the plus in the top left. Click add from git repository. Paste https://github.com/beef331/quicktimer.git .

Then in code:
```
using QuickTimer;

//All that is required to make a event that waits .5 seconds;
new Timer(.5f,true,()=>{Debug.Log("Hey that took .5 seconds")});
```
