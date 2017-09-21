# Every - Do something occasional

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
