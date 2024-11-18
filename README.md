# Every - Do something occasionally

Replaces
 
     int counter = 0;
     foreach(var x in MyLongList)
     {
           DoSomethingWith(x);
           ++counter;
           if (counter % 100 == 0)
           {
                Console.WriteLine("We've done {0}, so far", counter);
           }
     }
     
with:

      var counter = new Every(100, total=> Console.WriteLine("We've done {0}, so far", total));
     foreach(var x in MyLongList)
     {
           DoSomethingWith(x);
           ++counter;
     }      
In that example, every 100th time `++progress` is called, our reassuring message is printed, with the total number of item processed.

That's pretty much the lot of it.  You can write `++progress` or `progress++` or if you prefer something a bit more verbose, `progress.Next()`. All three are equivalent.

There's a `CallNow()` method, which does exactly that. (Use it after the loop, to, say, print the total number processed.)

And `Reset()` starts the count over from the beginning.

The constructor takes the number of iterations between calls the the `Action`, and a `Action<int>` (normally a lambda, but it could be a named method also) and takes an int (which will be equal to the total number of calls), and does whatever you need.

Featured in the blog article: https://honestillusion.com/blog/2017/10/12/every-doing-something-occasionally/

# Percentage --- Simplifying Progress Reporting

Sometimes, rather than knowing some fixed number of records is complete, you prefer knowing what percentage is complete.

Use is simple:

       var progress = new Percentage(numRecords, 
            (count, percentage) => Console.WriteLine($"We're at {percentage}% done.");
	   foreach(var item in MyLongList)
	   {
	          Process(item);
	          ++progress;
	   }


It's rather straightforward, much like it predecessor, except for one tricky part, which causes it to have two basic modes.

If the total number of items being processed is greater than 100, then the provided `Action<int, double>` will be called 100 times, once every time another percent of the total is complete.  The two parameters are the number of items processed, and the percentage complete, which will increase by one each time.

If the total is less than 100, then then action is called every time the `operator++` is called, in this case, with the percentage increased appropriately.  For example, if you only have 17 steps, then the percentage will step about 6 each time.

Of course, that is handled internally, so you don't have to worry about it. 

Featured in the blog article: https://honestillusion.com/blog/2024/11/18/percentage-simplifying-progress-reporting

