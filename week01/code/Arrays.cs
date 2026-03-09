public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Step 1: Create an array to store multiples of a number
        double[] result = new double[length];

        // Step 2: create a loop to fill each value of the array
        // The loop will run from 0 to -1 length
        for (int i = 0; i < length; i++) {
  
            // Step 3: Calculate the multiple of the number
            // if i is 0, then we increment it by 1 (i + 1)
            result[i] = number * (i + 1);
        }
        
        // Step Return result
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Step 1: Calculate the starting index of the slice that will be moved to the front by the amount 
        // data.Count - amount [create a variable to store the result]
        // Step 2: Get the start of the starting index that will be moved to the front using [GetRange(index, count)]
        // Step 3: Remove the slice from the list using [RemoveRange(index, amount)]
        // Step 4: Insert the slice at the begining of the list using [InsertRange(index, slice)]
        // Step 1
        int index = data.Count - amount;

        // Step 2
        List<int> slice = data.GetRange(index, amount);

        // Step 3
        data.RemoveRange(index, amount);

        // Step 4
        data.InsertRange(0, slice);
    }
}
