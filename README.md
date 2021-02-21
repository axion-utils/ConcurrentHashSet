## Introduction

[Nuget: Axion.Collections.ConcurrentHashSet](https://www.nuget.org/packages/Axion.Collections.ConcurrentHashSet/)

This package is a modified implementation of .NET's ConcurrentDictionary with a reduced memory footprint because it does not store any keys. 
It is similar to the i3arnon's [ConcurrentHashSet](https://github.com/i3arnon/ConcurrentHashSet), except that it includes more functionality.
Some additions include TryUpdate, TryAdd, TryGetValue, GetOrAdd, and AddOrUpdate. It also implements the non-generic version 
of ICollection. This was done for performance reasons and to allow the user to inspect modified and stored values in the collection.

## Example

```csharp
ConcurrentHashSet<string> set = new ConcurrentHashSet<string>()
{
	"string",
	"testing",
	"word",
	null,
};
Console.WriteLine("Count: " + set.Count);
// Count: 3

set.Clear();
Console.WriteLine(set.IsEmpty ? "Empty" : "Not Empty");
// Empty

for (int i = 0; i < 10; i++) {
	set.Add(i.ToString());
}

Console.WriteLine("Contents: " + string.Join(", ", set.OrderBy(x => x)));
// Contents: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9

foreach (string item in set.Take(5).ToList()) {
	if (set.TryRemove(item, out string removed)) {
		Console.WriteLine("Removed: " + removed);
	}
}
// Removed: 0
// Removed: 3
// Removed: 2
// Removed: 9
// Removed: 8

if (set.TryGetValue("7", out string str)) {
	Console.WriteLine(str + " was found");
}
// 7 was found

if (set.TryGetValue("8", out str)) {
	Console.WriteLine(str + " was found");
}
```

## License

The original source code comes from [ConcurrentDictionary](https://referencesource.microsoft.com/#mscorlib/system/Collections/Concurrent/ConcurrentDictionary.cs).

Their software is under the following license: [MICROSOFT REFERENCE SOURCE LICENSE (MS-RSL) license](https://referencesource.microsoft.com/license.html)

This license suggests that the code is free for "reference use only". I do not hold any rights to this software, nor do I intend to make any royalties from
the distribution of it. If you distribute this software then you do so at your own risk. If I hold any Copyright to this software, it is under the [MIT license](https://raw.githubusercontent.com/licenses/license-templates/master/templates/mit.txt).