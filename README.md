# UnityEngineAssets
A collction of tools, extensions, helpers, and other resources when working with Unity.

*Note: this library will accumulate tools and other features as time progresses.
You are free to make pull requests to add functionality, or make changes if you desire.*

**Verified Compatible Editors:**
- *2021.3.6f1 and up*

## Branches
There are currently 5 branches to submit pull requests to:
- **UnityEngineAssets.UnityEngine:** *This is the primary branch for anything that falls under the UnityEngine namespace.*
- **UnityEngineAssets.Unity:** *Similar to UnityEngineAssets, but exclusive to the namespaces Unity.Mathematics,
Unity.Burst, etc.*
- **UnityEngineAssets.Unsafe:** *The primary branch for anything marked with **/unsafe** regardless of namespace.*
- **UnityEngineAssets.UnityEditor:** *Editor windows, inspector, or other tools for the Unity editor.*
- **UnityEngineAssets.Scripts:** *MonoBehaviour scripts. Unlike other branches, this will house functionality.*

*Note: Most branches will follow the naming convention of Unity's namespaces. Large changes or additions might
be created under a seperate branch that wont be mentioned here.*

## Submitting Pull Requests

**Changes should always be made in the respective branch.**

For example: do not make a pull request that contains changes for the branch
*`UnityEngineAssets.Unsafe`* if changes are made in the *`/UnityEngineAssets/..`* folder!

## Installation
Add this package through the Package Manager using the *Add package from git URL...* option when using the clone repo HTTPS URL.

***OR***

By downloading the master branch and adding the package with the *Add package from disk...* option manually.
