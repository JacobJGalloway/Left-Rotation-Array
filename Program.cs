using System.Runtime.CompilerServices;

namespace LeftRotationArray 
{
    public class Program
    {
        static string rotateArr(int[] values, int[] rotations)
        {
            int[] maxIndex = new int[rotations.Length];

            // Get max value of input array
            int maxVal = -1;
            foreach (int num in values)
            {
                if (num > maxVal)
                {
                    maxVal = num;
                }
            }

            for (int r = 0; r < rotations.Length; r++)
            {
                // Handle case when rotations exceed an exact rotation count
                var iterationRotate = rotations[r] % values.Length;    

                // Storing rotated version of array for rotation array iteration
                int[] temp = new int[values.Length];

                // Copy last n - iteration elements to the front of temp
                for (int i = 0; i < values.Length - iterationRotate; i++)
                {
                    temp[i] = values[iterationRotate + i];
                }
                    
                // Copy the first elements to the back of temp
                for (int i = 0; i < iterationRotate; i++)
                {
                    temp[values.Length - iterationRotate + i] = values[i];
                }          

                Console.WriteLine(string.Join(", ", temp));
                
                maxIndex[r] = temp.IndexOf(maxVal);
            }

            return string.Join(", ", maxIndex); 
        }

        static void Main (string[] args)
        {
            // Take in the values and rotation array as single arguement

            string[] arrayStrings = args.Length == 1 && args[0].Contains(';') ? args[0].Split(';', StringSplitOptions.RemoveEmptyEntries) : args;

            int[][] arrays = arrayStrings
                .Select(arrStr => arrStr
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(numStr => int.Parse(numStr.Trim()))
                    .ToArray())
                .ToArray();

                int[] arr = arrays[0];
                int[] rot = arrays[1];

                Console.WriteLine(rotateArr(arr, rot));
                return;        
        }
    }
}




