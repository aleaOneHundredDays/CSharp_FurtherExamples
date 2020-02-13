using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class LinkedListExample
    {

        public  void Display(LinkedList<string> words, string test)
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

       public  void IndicateNode(LinkedListNode<string> node, string test)
        {
            Console.WriteLine(test);
            if (node.List == null)
            {
                Console.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }

    //This code example produces the following output:
    //
    //The linked list values:
    //the fox jumps over the dog

    //Test 1: Add 'today' to beginning of the list:
    //today the fox jumps over the dog

    //Test 2: Move first node to be last node:
    //the fox jumps over the dog today

    //Test 3: Change the last node to 'yesterday':
    //the fox jumps over the dog yesterday

    //Test 4: Move last node to be first node:
    //yesterday the fox jumps over the dog

    //Test 5: Indicate last occurence of 'the':
    //the fox jumps over (the) dog

    //Test 6: Add 'lazy' and 'old' after 'the':
    //the fox jumps over (the) lazy old dog

    //Test 7: Indicate the 'fox' node:
    //the (fox) jumps over the lazy old dog

    //Test 8: Add 'quick' and 'brown' before 'fox':
    //the quick brown (fox) jumps over the lazy old dog

    //Test 9: Indicate the 'dog' node:
    //the quick brown fox jumps over the lazy old (dog)

    //Test 10: Throw exception by adding node (fox) already in the list:
    //Exception message: The LinkedListExample node belongs a LinkedListExample.

    //Test 11: Move a referenced node (fox) before the current node (dog):
    //the quick brown jumps over the lazy old fox (dog)

    //Test 12: Remove current node (dog) and attempt to indicate it:
    //Node 'dog' is not in the list.

    //Test 13: Add node removed in test 11 after a referenced node (brown):
    //the quick brown (dog) jumps over the lazy old fox

    //Test 14: Remove node that has the value 'old':
    //the quick brown dog jumps over the lazy fox

    //Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':
    //the quick brown dog jumps over the lazy rhinoceros

    //Test 16: Copy the list to an array:
    //the
    //quick
    //brown
    //dog
    //jumps
    //over
    //the
    //lazy
    //rhinoceros

    //Test 17: Clear linked list. Contains 'jumps' = False
    //
}

