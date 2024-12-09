using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the directory to search in:");
        string directoryPath = Console.ReadLine();

        Console.WriteLine("Enter the file name to search for:");
        string fileName = Console.ReadLine();

        try
        {
            // Create an instance of FileFinder and call its method
            FileFinder fileFinder = new FileFinder();
            string result = fileFinder.FindFile(directoryPath, fileName);

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine($"File found at: {result}");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
class FileFinder
{
    /// <summary>
    /// Searches for a specific file in the given directory and its subdirectories.
    /// </summary>
    /// <param name="directoryPath">The directory to start the search.</param>
    /// <param name="fileName">The name of the file to search for.</param>
    /// <returns>The full path of the file if found, otherwise null.</returns>
    public string FindFile(string directoryPath, string fileName)
    {
        // Validate the directory
        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"The directory '{directoryPath}' does not exist.");
        }

        // Search for the file in the current directory
        string[] files = Directory.GetFiles(directoryPath, fileName);
        if (files.Length > 0)
        {
            return files[0]; // Return the first match
        }

        // Recursively search in subdirectories
        string[] subdirectories = Directory.GetDirectories(directoryPath);
        foreach (string subdirectory in subdirectories)
        {
            string result = FindFile(subdirectory, fileName);
            if (!string.IsNullOrEmpty(result))
            {
                return result; // Return the result if found
            }
        }

        return null; // File not found
    }
}