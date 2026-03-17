using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 3);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 8);
        priorityQueue.Enqueue("George", 6);

        Assert.AreEqual("Sue", priorityQueue.Dequeue());
        Assert.AreEqual("George", priorityQueue.Dequeue());
        Assert.AreEqual("Tim", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "The queue is empty.");

        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 1);
        priorityQueue.Enqueue("Y", 2);
        priorityQueue.Enqueue("Z", 3);
        
        Assert.AreEqual("Z", priorityQueue.Dequeue());
        Assert.AreEqual("Y", priorityQueue.Dequeue());
        Assert.AreEqual("X", priorityQueue.Dequeue());
        
        // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}