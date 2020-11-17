# 🚀 TightBool
A .NET Boolean-like type that tries to actually store a true/false value in one bit.

## ❓ Why use this?
Realistically, you wouldn't have to use this. It's just me experimenting whether I could store a boolean per bit. It _does_ actually use a bit per boolean, but this does add more instructions, meaning the computing cost is a little bit higher. If you actually want to save storage (eg in files) when you are using a lot of booleans this might in some cases save some disk space, at the cost of some computing. It's really up to you whether you want to save memory or save computing cost.

## 🤔 Why did you make this?
A meme was shared on Discord about a boolean actually using a byte to store data. It means 3 bits are actually unused. I was curious whether I could make something that would assign a single bit per boolean. I could, but really it didn't come with any big benefits.

## 😂 What was the meme?
![The meme](https://i.redd.it/8ceh0d66fdz51.jpg)