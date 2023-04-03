using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRMApp.ControlBase
{
   public sealed class DropDownObject
   {
      private string code;
      private string description;

      public DropDownObject(string code, string description)
      {
         this.code = code;
         this.description = description;
      }

      public string Code
      {
         get
         {
            return this.code;
         }
         set
         {
            this.code = value;
         }
      }

      public string Description
      {
         get
         {
            return this.description;
         }
         set
         {
            this.description = value;
         }
      }
   }
}
