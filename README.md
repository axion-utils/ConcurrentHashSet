## Introduction

[Nuget: Axion.ConcurrentHashSet](https://www.nuget.org/packages/Axion.ConcurrentHashSet/)

This package is a modified implementation of .NET's ConcurrentDictionary with a reduced memory footprint because it does not store any keys. 
It is similar to the i3arnon's [ConcurrentHashSet](https://github.com/i3arnon/ConcurrentHashSet), except that it includes more functionality.
Some additions include TryUpdate, TryAdd, TryGetValue, GetOrAdd, and AddOrUpdate. It also implements the non-generic version 
of ICollection. This was done for performance reasons and to allow the user to inspect modified and stored values in the collection.

## Methods

```csharp
bool Add(T value);
bool Remove(T value);
bool TryAdd(T value, out T currentValue);
bool TryRemove(T value, out T oldValue);
bool TryUpdate(T value);
bool TryGetValue(T value, out T currentValue);
T GetOrAdd(T value);
void AddOrUpdate(T value);
```

## License

The original source code comes from [ConcurrentDictionary](https://referencesource.microsoft.com/#mscorlib/system/Collections/Concurrent/ConcurrentDictionary.cs).

Their software is under the following license: [MICROSOFT REFERENCE SOURCE LICENSE (MS-RSL) license](https://referencesource.microsoft.com/license.html)

This license suggests that the code is free for "reference use only". I do not hold any rights to this software, nor do I intend to make any royalties from
the distribution of it. If you distribute this software then you do so at your own risk. If I hold any copyright to this software then it is under the 
[MIT license](https://raw.githubusercontent.com/licenses/license-templates/master/templates/mit.txt).
