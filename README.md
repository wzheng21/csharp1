# First C# experiment on iterating over mates/entities

It is just too hard to code with SolidWorks API in C++. It
requires quite a bit knowledge on Windows COM interface.

On the other hand, C# API is very friendly for developers.

Under csharp1 folder:

-- Program.cs: top-level setup and teardown for SolidWorks applications

-- MateEntityInfo.cs: MateEntityInfo class to contain any related data structures for MateEntity.

-- MateEntityHandler.cs: processes input assembly model and collect entity info
