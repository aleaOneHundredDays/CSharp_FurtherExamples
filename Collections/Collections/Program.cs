using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections
{
    class Program
    {

        // Simple business object. A PartId is used to identify the type of part 
        // but the part name can change. 
        public class Part : IEquatable<Part>
        {
            public string PartName { get; set; }

            public int PartId { get; set; }

            public override string ToString()
            {
                return "ID: " + PartId + "   Name: " + PartName;
            }
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                Part objAsPart = obj as Part;
                if (objAsPart == null) return false;
                else return Equals(objAsPart);
            }
            public override int GetHashCode()
            {
                return PartId;
            }
            public bool Equals(Part other)
            {
                if (other == null) return false;
                return (this.PartId.Equals(other.PartId));
            }
            // Should also override == and != operators.
        }



        static void Main(string[] args)

        {
            // Queue Example

            // Creates and initializes a new Queue. (FIFO)
            Queue myQ = new Queue();
            myQ.Enqueue("Aardvarks");    // put things in the queue
            myQ.Enqueue("Budgies");
            myQ.Enqueue("Cats");

            // Displays the properties and values of the Queue.
            Console.WriteLine("myQ");
            Console.WriteLine("\tCount:    {0}", myQ.Count);
            Console.Write("\tValues:");

            foreach (Object obj in myQ)
                Console.Write("    {0}", obj);
            Console.WriteLine();

            string thefirstThing = (string)myQ.Dequeue();  // remove item from front of queue (Aardvarks)
            Console.WriteLine(thefirstThing);    // Print out Aardvarks 

            foreach (Object obj in myQ)          // just leaves budgies and cats
                Console.Write("    {0}", obj);
            Console.WriteLine();


            // Stack Example
            // Creates and initializes a new Stack.  (LIFO)
            Stack myStack = new Stack();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("!");  // <--- ITEM AT TOP OF STACK

            // Displays the properties and values of the Stack.
            Console.WriteLine("myStack");
            Console.WriteLine("\tCount:    {0}", myStack.Count);
            Console.Write("\tValues:");
            PrintValues(myStack);

            foreach (Object obj in myStack)
                Console.Write("    {0}", obj);
            Console.WriteLine();

            string currentString = (string) myStack.Peek();
            Console.WriteLine($"myStack - Gonna Pop this value: {currentString}");
            string theTop = (string) myStack.Pop();  // its gone

            Console.WriteLine("myStack - NOW AFTER POP");
            Console.WriteLine("\tCount is now:{0}", myStack.Count);
            Console.Write("\tValues:");
            PrintValues(myStack);


            foreach (Object obj in myStack)
                Console.Write("    {0}", obj);
            Console.WriteLine();




            // LIST EXAMPLE
            // Create a list of parts.
            // Generic so strongly typed
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part { PartName = "shift lever", PartId = 1634 });


            Part sparePart = parts[0];
            Console.WriteLine(sparePart);

            // Write out the parts in the list. This will call the overridden ToString method
            // in the Part class.
            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }


            // LINKED LIST EXAMPLE

            LinkedListExample linkListExample = new LinkedListExample();

            // Create the link list.
            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);   // Create LinkedList of type string

            linkListExample.Display(sentence, "The linked list values:");
            Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
                sentence.Contains("jumps"));

            // Add the word 'today' to the beginning of the linked list.
            sentence.AddFirst("today");
            linkListExample.Display(sentence, "Test 1: Add 'today' to beginning of the list:");

            // Move the first node to be the last node.
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            linkListExample.Display(sentence, "Test 2: Move first node to be last node:");

            // Change the last node to 'yesterday'.
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            linkListExample.Display(sentence, "Test 3: Change the last node to 'yesterday':");

            // Move the last node to be the first node.
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            linkListExample.Display(sentence, "Test 4: Move last node to be first node:");

            // Indicate the last occurence of 'the'.
            sentence.RemoveFirst();
            LinkedListNode<string> current = sentence.FindLast("the");
            linkListExample.IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

            // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            linkListExample.IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

            // Indicate 'fox' node.
            current = sentence.Find("fox");
            linkListExample.IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox':
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            linkListExample.IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("dog");
            linkListExample.IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            // The AddBefore method throws an InvalidOperationException
            // if you try to add a node that already belongs to a list.
            Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
            try
            {
                sentence.AddBefore(current, mark1);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Exception message: {0}", ex.Message);
            }
            Console.WriteLine();


            sentence.Remove("the");
            sentence.Remove("fish");  // Not in the list so does nothing

            // Remove the node referred to by mark1, and then add it
            // before the node referred to by current.
            // Indicate the node referred to by current.
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            linkListExample.IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

            // Remove the node referred to by current.
            sentence.Remove(current);
            linkListExample.IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

            // Add the node after the node referred to by mark2.
            sentence.AddAfter(mark2, current);
            linkListExample.IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

            // The Remove method finds and removes the
            // first node that that has the specified value.
            sentence.Remove("old");
            linkListExample.Display(sentence, "Test 14: Remove node that has the value 'old':");

            // When the linked list is cast to ICollection(Of String),
            // the Add method adds a node to the end of the list.
            sentence.RemoveLast();
            ICollection<string> icoll = sentence;
            icoll.Add("rhinoceros");
            linkListExample.Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

            Console.WriteLine("Test 16: Copy the list to an array:");
            // Create an array with the same number of
            // elements as the inked list.
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);

            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }

            // Release all the nodes.
            sentence.Clear();

            Console.WriteLine();
            Console.WriteLine("Test 17: Clear linked list. Contains 'jumps' = {0}",
                sentence.Contains("jumps"));

            Console.ReadLine();
        

        //private static void Display(LinkedList<string> words, string test)
        //{
        //    Console.WriteLine(test);
        //    foreach (string word in words)
        //    {
        //        Console.Write(word + " ");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine();
        //}

        //private static void IndicateNode(LinkedListNode<string> node, string test)
        //{
        //    Console.WriteLine(test);
        //    if (node.List == null)
        //    {
        //        Console.WriteLine("Node '{0}' is not in the list.\n",
        //            node.Value);
        //        return;
        //    }

        //    StringBuilder result = new StringBuilder("(" + node.Value + ")");
        //    LinkedListNode<string> nodeP = node.Previous;

        //    while (nodeP != null)
        //    {
        //        result.Insert(0, nodeP.Value + " ");
        //        nodeP = nodeP.Previous;
        //    }

        //    node = node.Next;
        //    while (node != null)
        //    {
        //        result.Append(" " + node.Value);
        //        node = node.Next;
        //    }

        //    Console.WriteLine(result);
        //    Console.WriteLine();
        //}








        ////////



        // ARRAYLIST
        // Creates and initializes a new ArrayList.
        // Can hold different types of data
        // Use Add/Remove to insert/delete elements

        //ArrayList myAL = new ArrayList();
        //    myAL.Add("HelloAgain");
        //    myAL.Add("!");
        //    myAL.Add("World");
        //    myAL.Add("!");
        //    myAL.Add("Hello There");
        //    // myAL.Add(12345);
        //    //myAL.Add(1);
        //    //myAL.Add(true);
          



        //    bool bContains = myAL.Contains("!");
        //    int hereItIs = myAL.IndexOf("Hello");  // returns -1
        //   // int hereItIs2 = myAL.LastIndexOf("!");

        //    myAL.Sort();

        //    // Displays the properties and values of the ArrayList.
        //    Console.WriteLine("myAL");
        //    Console.WriteLine("    Count:    {0}", myAL.Count);
        //    Console.WriteLine("    Capacity: {0}", myAL.Capacity);
        //    Console.Write("    Values:");
        //    PrintValues(myAL);

        //    // Sorting with IComparable

        //    // create and initalize new ArrayList, i.e. mylist 
        //    ArrayList mylist = new ArrayList();
        //    mylist.Add("Welcome");
        //    mylist.Add("to");
        //    mylist.Add("geeks");
        //    mylist.Add("for");
        //    mylist.Add("geeks");
        //    mylist.Add("2");

        //    IComparer Comp1 = new myClass();

        //    // sort the value of ArrayList 
        //    // using Sort(IComparer) method 
        //    mylist.Sort(Comp1);

        //    foreach (Object ob in mylist)
        //    {
        //        Console.WriteLine(ob);
        //    }


        //    // HASHTABLE
        //    // Create a new hash table.
        //    // Uses Add/Remove
        //    Hashtable openWith = new Hashtable();

        //    // Add some elements to the hash table. There are no 
        //    // duplicate KEYS, but some of the VALUES are duplicates (which is OK).
        //    openWith.Add("txt", "notepad.exe");
        //    openWith.Add("bmp", "paint.exe");
        //    openWith.Add("dib", "paint.exe");
        //    openWith.Add("rtf", "wordpad.exe");

           
        //    // Now make it throw an error:
        //    // The Add method throws an exception if the new key is 
        //    // already in the hash table.
        //    try
        //    {
        //        openWith.Add("txt", "winword.exe");
        //    }
        //    catch
        //    {
        //        Console.WriteLine("An element with Key = \"txt\" already exists.");
        //    }


        //    /// Dictionary
        //    // Create a new dictionary of strings, with string keys.
        //    //
        //    Dictionary<string, string> openWith2 = new Dictionary<string, string>();

        //    // Add some elements to the dictionary. There are no 
        //    // duplicate keys, but some of the values are duplicates.
        //    openWith2.Add("txt", "notepad.exe");
        //    openWith2.Add("bmp", "paint.exe");
        //    openWith2.Add("dib", "paint.exe");
        //    openWith2.Add("rtf", "wordpad.exe");

           

        //    // The Add method throws an exception if the new key is 
        //    // already in the dictionary.
        //    try
        //    {
        //        openWith2.Add("txt", "winword.exe");
        //    }
        //    catch (ArgumentException)
        //    {
        //        Console.WriteLine("An element with Key = \"txt\" already exists.");
        //    }

        //    // The Item property is another name for the indexer, so you 
        //    // can omit its name when accessing elements. 
        //    Console.WriteLine("For key = \"rtf\", value = {0}.",
        //        openWith2["rtf"]);

        //    // The indexer can be used to change the value associated
        //    // with a key.
        //    openWith2["rtf"] = "winword.exe";
        //    Console.WriteLine("For key = \"rtf\", value = {0}.",
        //        openWith2["rtf"]);

        //    // If a key does not exist, setting the indexer for that key
        //    // adds a new key/value pair.
        //    openWith2["doc"] = "winword.exe";

        //    // The indexer throws an exception if the requested key is
        //    // not in the dictionary.
        //    try
        //    {
        //        Console.WriteLine("For key = \"tif\", value = {0}.",
        //            openWith2["tif"]);
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        Console.WriteLine("Key = \"tif\" is not found.");
        //    }

        //    // When a program often has to try keys that turn out not to
        //    // be in the dictionary, TryGetValue can be a more efficient 
        //    // way to retrieve values.
        //    string value = "";
        //    if (openWith2.TryGetValue("tif", out value))
        //    {
        //        Console.WriteLine("For key = \"tif\", value = {0}.", value);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Key = \"tif\" is not found.");
        //    }

        //    // ContainsKey can be used to test keys before trying insert
        //    if (!openWith2.ContainsKey("ht"))
        //    {
        //        openWith2.Add("ht", "hypertrm.exe");
        //        Console.WriteLine("Value added for key = \"ht\": {0}",
        //            openWith2["ht"]);
        //    }

        //    // When you use foreach to enumerate dictionary elements,
        //    // the elements are retrieved as KeyValuePair objects.
        //    Console.WriteLine();
        //    foreach (KeyValuePair<string, string> kvp in openWith)
        //    {
        //        Console.WriteLine("Key = {0}, Value = {1}",
        //            kvp.Key, kvp.Value);
        //    }

        //    // To get the values alone, use the Values property.
        //    Dictionary<string, string>.ValueCollection valueColl =
        //        openWith2.Values;

        //    // The elements of the ValueCollection are strongly typed
        //    // with the type that was specified for dictionary values.
        //    Console.WriteLine();
        //    foreach (string s in valueColl)
        //    {
        //        Console.WriteLine("Value = {0}", s);
        //    }

        //    // To get the keys alone, use the Keys property.
        //    Dictionary<string, string>.KeyCollection keyColl =
        //        openWith2.Keys;

        //    // The elements of the KeyCollection are strongly typed
        //    // with the type that was specified for dictionary keys.
        //    Console.WriteLine();
        //    foreach (string s in keyColl)
        //    {
        //        Console.WriteLine("Key = {0}", s);
        //    }

        //    // Use the Remove method to remove a key/value pair.
        //    Console.WriteLine("\nRemove(\"doc\")");
        //    openWith2.Remove("doc");

        //    if (!openWith2.ContainsKey("doc"))
        //    {
        //        Console.WriteLine("Key \"doc\" is not found.");
        //    }

        //    /* This code example produces the following output:

        //    An element with Key = "txt" already exists.
        //    For key = "rtf", value = wordpad.exe.
        //    For key = "rtf", value = winword.exe.
        //    Key = "tif" is not found.
        //    Key = "tif" is not found.
        //    Value added for key = "ht": hypertrm.exe

        //    Key = txt, Value = notepad.exe
        //    Key = bmp, Value = paint.exe
        //    Key = dib, Value = paint.exe
        //    Key = rtf, Value = winword.exe
        //    Key = doc, Value = winword.exe
        //    Key = ht, Value = hypertrm.exe

        //    Value = notepad.exe
        //    Value = paint.exe
        //    Value = paint.exe
        //    Value = winword.exe
        //    Value = winword.exe
        //    Value = hypertrm.exe

        //    Key = txt
        //    Key = bmp
        //    Key = dib
        //    Key = rtf
        //    Key = doc
        //    Key = ht

        //    Remove("doc")
        //    Key "doc" is not found.
        //    */



        }

        // Calls CaseInsensitiveComparer.Compare 
        // with the parameters REVERSED.  (See b,a in Compare(b,a))
        public class myClass : IComparer
        {

            int IComparer.Compare(Object a, Object b)
            {
                return ((new CaseInsensitiveComparer()).Compare(b, a));
            }
        }

        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }


        /////////////////Dictionary/////////////
        
      



    }
}
