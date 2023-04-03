namespace Brokery.Controls
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

      public override bool Equals(object obj)
      {
         var item = obj as DropDownObject;
         if (item == null)
            return false;
         return item.Code == this.Code;
      }
   }
}
