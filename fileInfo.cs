using System;
using System.IO;
using System.Collections;

public class fileInfo
{
    // mutators and accessors for info relating to a file
    public string fileName { get; set; }
    public string fileLocation { get; set; }
    public bool locationValid { get; set; } // set to true once address is verified

    // initialize variables
    public fileInfo()
    {
        fileName = "";
        fileLocation = "";
        locationValid = false;
    }


    public void getFilesLocation()
    {
        // store the file address with the file name given by user
        string fileAddress = Directory.GetCurrentDirectory() + @"\" + fileName;
        
        // call function to check if file can be found in directory
        if (File.Exists(fileAddress) == true)
        {
            fileLocation = fileAddress;
            locationValid = true; // set object to true as location has been validated
            return;
        }
        // else report error in finding
        Console.WriteLine("Problem finding file: "+ fileName); // inform user of missing file
        locationValid = false; // set object to false, ensuring indication of failure to validate
    }
}
