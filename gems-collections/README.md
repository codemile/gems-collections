gems-collections
================

A library of collection related utilities for C#

###Dictionary/AutoDictionary

Automatically adds new entries when using `this[key] =` to assign a value.

###Dictionary/CountDictionary

A simple `Dictionary<T,int>` that counts the number of times a value is assigned to index `T`.

###Dictionary/ReadOnlyDictionary

A readonly dictionary.

###Dictionary/ThreadPoolDictionary

This is actually a dictionary pool where a new dictionary is assigned for each thread that accesses.

###Enumerable/Enumerated

An extension of tools for LINQ

###Enumerable/Strings

An extension of tools used for string values in LINQ

###List/LimitedList

A `List<T>` type that will not grow larger then a limited size.

###List/WeightedList

A `List<T>` where items are added with an integer weight value. Use `getWeight(i)` to see the `0-1` normalized weight of an item relative to all other items in the list.