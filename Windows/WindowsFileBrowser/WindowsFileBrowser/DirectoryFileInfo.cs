using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WindowsFileBrowser
{
    /// <summary>
    /// DirectoryFileInfo combines information contained in both DirectoryInfo and FileInfo classes
    /// </summary>
    class DirectoryFileInfo
    {
        public FileInfo file;
        public DirectoryInfo directory;

        string sizeDivision;
        decimal length;
        decimal Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                if(length > 1024)
                {
                    length = length / 1024;
                    if(length > 1024)
                    {
                        length = length / 1024;
                        if(length > 1024)
                        {
                            length = length / 1024;
                            if(length > 1024)
                            {
                                length = length / 1024;
                                if(length > 1024)
                                {

                                }
                                else
                                {
                                    sizeDivision = "tb";
                                }
                            }
                            else
                            {
                                sizeDivision = "gb";
                            }
                        }
                        else
                        {
                            sizeDivision = "mb";
                        }
                    }
                    else
                    {
                        sizeDivision = "kb";
                    }
                }
                else
                {
                    sizeDivision = "b";
                }
            }
        }

        public string Name
        {
            get
            {
                if(directory != null)
                {
                    return directory.Name;
                }
                else
                {
                    return file.Name;
                }
            }
        }
        public string Size
        {
            get
            {
                return Length.ToString("#.##") + " " + sizeDivision;
            }
        }
        public string FileType
        {
            get
            {
                if (file != null)
                {
                    if (file.Extension == ".jpg")
                    {
                        return "JPG file";
                    }
                    else if (file.Extension == ".png")
                    {
                        return "PNG File";
                    }
                    else if (file.Extension == ".exe")
                    {
                        return "Executable";
                    }

                    return "Unknown File";
                }
                else
                {
                    return "File Folder";
                }
            }
        }
        public string Extension
        {
            get
            {
                if(directory != null)
                {
                    return directory.Extension;
                }
                else
                {
                    return file.Extension;
                }
            }
        }
        public DateTime CreationDate
        {
            get
            {
                if(directory != null)
                {
                    return directory.CreationTime;
                }
                else
                {
                    return file.CreationTime;
                }
            }
            set
            {
                if(directory != null)
                {
                    directory.CreationTime = value;
                }
                else
                {
                    file.CreationTime = value;
                }
            }
        }
        public DateTime LastModified
        {
            get
            {
                if(directory != null)
                {
                    return directory.LastWriteTime;
                }
                else
                {
                    return file.LastWriteTime;
                }
            }
            set
            {
                if(directory != null)
                {
                    directory.LastWriteTime = value;
                }
                else
                {
                    file.LastWriteTime = value;
                }
            }
        }

        public DirectoryFileInfo(FileInfo file)
        {
            this.file = file;
            this.directory = null;

            this.Length = file.Length;
        }

        
        public DirectoryFileInfo(DirectoryInfo directory)
        {
            this.file = null;
            this.directory = directory;
        }


    }
}
