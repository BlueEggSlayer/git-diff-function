using System;
using System.IO;

public class dataController
{
    // compare two files, return true if they are the same, false if different
    public bool compareFiles(string fileAddressA, string fileAddressB)
    {
        // stores the line's current data
        int currentLineData;
        // string var to store lines in the files
        string lineDataA = "";
        string lineDataB = "";

        try
        {
            // create instances of the stream reader class inorder to read from
            // the user's inputted files, the statement 'using' closes the streamreader after the process
            using (StreamReader fileReaderA = new StreamReader(fileAddressA))
            using (StreamReader fileReaderB = new StreamReader(fileAddressB))
            {
                // while both files have lines, continue
                while ((lineDataA = fileReaderA.ReadLine()) != null && (lineDataB = fileReaderB.ReadLine()) != null)
                {
                    // checks if lines are different
                    if (lineDataA.ToLower() != lineDataB.ToLower())
                    {
                        return false; // return false if theres a difference
                    }
                }
            }
        }
        catch (Exception E)
        {
            Console.WriteLine("Error while reading file");
            Console.WriteLine("Caught an exception: " + E.Message);
        }

        return true; // return true if all operations are completed successfully

    }

    // format user input
    public string commandInput(string fileName)
    {
        return fileName = fileName.Trim().Substring(5); // remove unnecessary characters to get file names
    }
}
