# UnityTimer
Simple and easy to use Unity timer.

## How To Use
Go to the Unity Package Manager. Cick the plus in the top left. Click add from git repository. Paste https://github.com/beef331/quicktimer.git .

Then in code:
```
using QuickTimer;

//All that is required to make a event that waits .5 seconds;
new Timer(.5f,()=>{Debug.Log("Hey that took .5 seconds")});

//It also supports awaiting which is done similarly
await Timer.Start(.5);
```
