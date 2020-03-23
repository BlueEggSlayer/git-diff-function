using System;
using System.IO;
using System.Collections;

namespace git_diff
{
    class Program
    {
        static void Main(string[] args)
        {
            // variable to store the formatted input command
            string inputtedFileNames;

            // set current directory to folder where files are
            Directory.SetCurrentDirectory(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\file_folder");
            
            // create two fileInfo objects that store file's info and validates address
            fileInfo fileA = new fileInfo();
            fileInfo fileB = new fileInfo();

            // data controller used to format, open and compare files
            dataController informationController = new dataController();

            Console.WriteLine("Running git diff program, ensure your input is in this format \"diff a.txt b.txt\" ");

            while (fileA.locationValid == false || fileB.locationValid == false)
            {
                Console.WriteLine("Input a command: ");
               
                inputtedFileNames = Console.ReadLine();

                // check if diff command was used
                if (inputtedFileNames.StartsWith("diff"))
                {
                    // Format the input and store in the variable
                    inputtedFileNames = informationController.commandInput(inputtedFileNames);
                    
                    // if there are two file names inputted do the following
                    if (inputtedFileNames.Split().Length == 2)
                    {
                        // set file names
                        fileA.fileName = inputtedFileNames.Split()[0];
                        fileB.fileName = inputtedFileNames.Split()[1];
                        // run validation on file existance
                        fileA.getFilesLocation();
                        fileB.getFilesLocation();

                        // if a file can't be found, notify user
                        if (fileA.locationValid == false || fileB.locationValid == false)
                        {
                            Console.WriteLine("Location is not found, please check input again and ensure files are in the file_folder");
                        }
                    }
                    else // if the data can't be split properly (into two file names), format is entered wrong and loop continues 
                    {
                        Console.WriteLine("Please ensure you entered in this format \"diff a.txt b.txt\" ");
                    }
                } else
                {
                    Console.WriteLine("Please ensure you use the diff keyword");
                }
            }

            // compare the two files to see if they're different, reply appropriately
            if (informationController.compareFiles(fileA.fileLocation, fileB.fileLocation)==true)
            {
                Console.WriteLine(fileA.fileName + " and " + fileB.fileName + " are not different");
            }
            else
            {
                Console.WriteLine(fileA.fileName + " and " + fileB.fileName + " are different");
            }

        }
    }
}
