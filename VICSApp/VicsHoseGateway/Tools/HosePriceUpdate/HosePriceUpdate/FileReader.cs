using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HosePriceUpdate
{
   public abstract class FileReader
   {
      // Fields
      protected bool isOpen;
      protected long length;
      protected BinaryReader reader;
      protected string fileName;
      protected long fileLength;

      // Methods
      protected FileReader(string sFileName)
      {
         this.fileName = sFileName;
      }

      public void Open()
      {
         var input = new FileStream(this.fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
         this.reader = new BinaryReader(input);
         this.fileLength = input.Length;
         this.length = 0L;
         this.isOpen = true;
      }

      public void Close()
      {
         this.isOpen = false;
         this.reader.Close();
         this.reader = null;
      }

      public abstract bool Read();

      // Properties
      public bool EOF
      {
         get
         {
            if (this.isOpen)
            {
               return (this.length >= this.fileLength);
            }
            return true;
         }
      }

      public bool IsOpen
      {
         get
         {
            return this.isOpen;
         }
      }

      public long Length
      {
         get
         {
            return this.Length;
         }
      }

      public abstract int NumberOfRecords { get; }
   }



}
