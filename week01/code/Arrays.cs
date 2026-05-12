using System;
using System.Collections.Generic;

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
        // Step 1: creat a new array with the required length
        // Step 2: Loop through each index in the array
        // Step 3: For each position, calculate the multiples of the number. The first position should be number * 1, the second position should be number * 2, and so on.
        // Step 4: Return the array of multiples

        double[] result  = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

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
        // Step 1: Find the starting index of the values that will move to the front. This will be data.Count - amount.
        // Step 2: Use GetRange to take the last 'amount' values from the list.
        // Step 3: Use GetRange again to take the remaining values from the beginning of the list.
        // Step 4: Clear the original list.
        // Step 5: Add the rotated values back into the list in the correct order. 
        // First add the right-sides values, then add the left-side values.

        int splitIndex = data.Count - amount;

        List<int> rightSide = data.GetRange(splitIndex, amount);
        List<int> leftSide = data.GetRange(0, splitIndex);

        data.Clear();

        data.AddRange(rightSide);
        data.AddRange(leftSide);
    }
}
