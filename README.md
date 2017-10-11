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

