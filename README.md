# 🚀 TightBool
A .NET Boolean-like type that tries to actually store a true/false value in one bit.

## ❓ Why use this?
Realistically, you wouldn't have to use this. It's just me experimenting whether I could store a boolean per bit. It _does_ actually use a bit per boolean, but this does add more instructions, meaning the computing cost is a little bit higher. If you actually want to save storage (eg in files) when you are using a lot of booleans this might in some cases save some disk space, at the cost of some computing. It's really up to you whether you want to save memory or save computing cost.

## 🤔 Why did you make this?
A meme was shared on Discord about a boolean actually using a byte to store data. It means 7 bits are actually unused. I was curious whether I could make something that would assign a single bit per boolean. I could, but really it didn't come with any big benefits.

## ✏ Usage
```cs
// Creating a new TightBool.
var EightBools = new TightBool();

// Setting the second value to true.
EightBools[1] = true;

if(EightBools[0])
{
	// Won't run because it's false by default.
}
if(EightBools[1])
{
	// Will run, because it's set to true.
}

// Creating a new TightBool with values 3 and 7 (fourth and eighth values) to be true.
var EightMoreBools = new TightBool(val3: true, val7: true);
```

Here TightBool is interchangeable with other TightBool-related types. Here's a table listing all of them.
| Type           | Amount of booleans | Underlying storage |
|----------------|--------------------|--------------------|
| TightBool      | 8                  | byte (8 bits)      |
| ShortTightBool | 16                 | short (16 bits)    |
| IntTightBool   | 32                 | int (32 bits)      |
| LongTightBool  | 64                 | long (64 bits)     |

For the last type of TightBool, the amount of bits will be flexible in pairs of 8. This will only save memory when a lot of values are used. For smaller sets of booleans the previous types are recommended to be used.

## 😂 What was the meme?
![The meme](https://i.redd.it/8ceh0d66fdz51.jpg)
