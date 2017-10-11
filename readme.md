## Every --- Doing Something Occasionally

I recently had a need for a class I wrote a long time ago in C++.  But I was working in C#, so I had to recreate it.  Fortunately. with lambdas and closures. the C# version was much easier than the last one.

Sometimes, when looping through a large collection, you need to do something -- like pagination or a progress message, not on every iteration, but only after a number of them.   For that, we have the `Every` class.

Basic usage:

       var progress = new Every(100, (total) => Console.WriteLine($"We've completed {total} items.");
	   foreach(var item in ReallyBigCollection)
	   {
	          Process(item);
	          ++progress;
	   }
	   
In that example, every 100th time `++progress` is called, our reassuring message is printed, with the total number of item processed.

That's pretty much the lot of it.  You can write `++progress` or `progress++` or if you prefer something a bit more verbose, `progress.Next()`. All three are equivalent.

There's a `CallNow()` method, which does exactly that. (Use it after the loop, to, say, print the total number processed.)

And `Reset()` starts the count over from the beginning.

The constructor takes the number of iterations between calls the the `Action`, and a `Action<int>` (normally a lambda, but it could be a named method also) and takes an int (which will be equal to the total number of calls), and does whatever you need.

