# Windows Forms Clipboard Watcher

WindowsFormsClipboardWatcher is a simple library that allows you to watch the Windows clipboard and be notified of any changes.

## Quickstart

Install the library, and then use it as follows:

```csharp
ClipboardWatcher.ClipboardUpdate += (sender, eventArgs) =>
{
    Console.WriteLine($"Clipboard text changed to: {Clipboard.GetText()}");
};
```

## Installation

Just grab it from [NuGet](https://www.nuget.org/packages/WindowsFormsClipboardWatcher/)

```
PM> Install-Package WindowsFormsClipboardWatcher
```

```
$ dotnet add package WindowsFormsClipboardWatcher
```

## License and copyright

Copyright Matthew King.
Distributed under the [MIT License](http://opensource.org/licenses/MIT).
Refer to license.txt for more information.
