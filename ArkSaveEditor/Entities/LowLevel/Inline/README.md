# What is inline?

Inline is the way Ark stores data....inline, without a name table. It's very similar to the normal DotArk way of saving data, but this way does not use a name table.

# Inline format
Type		| Description	| Value
========================================================
Ark Class name 	| Prop name 	| SavedPlayerDataVersion
Ark Class name	| Prop type	| IntProperty
Integer32	| Prop length	| 4
Integer32	| Prop index?	| 0
Value		| Prop data	| 7
