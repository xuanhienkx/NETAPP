using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace SMS.Common.Action
{
    public class StandardCondition : AbstractCondition
    {
        private const string CondOprNotEqual = "ISNOTEQUALTO";
        private const string CondOprEqual = "ISEQUALTO";
        private const string CondOprContains = "CONTAINS";
        private const string CondOprOver = "OVER";
        private const string CondOprBelow = "BELOW";
        private const string CondOprEqualOwer = "ISEQUALOROVER";
        private const string CondOprEqualBelow = "ISEQUALORBELOW";

        private const string CondOprNull = "NULL";
        private const string CondOprNone = "NONE";
        private const string CondOprNotNull = "ISNOTNULL";
        private const string CondOprNotNone = "ISNOTNONE";

        private const string CondOprNotEqual2 = "NE";
        private const string CondOprEqual2 = "E";
        private const string CondOprOver2 = "O";
        private const string CondOprBelow2 = "B";
        private const string CondOprEqualOwer2 = "EO";
        private const string CondOprEqualBelow2 = "EB";

        private const string CondTypeString = "STRING";
        private const string CondTypeDecimal = "DECIMAL";
        private const string CondTypeInt = "INTEGER";
        private const string CondTypeBool = "BOOLEAN";
        private const string CondTypeDate = "DATETIME";

        private const string CondTypeBoolTrue = "TRUE";
        private const string CondTypeBoolTrue2 = "T";
        private const string CondTypeBoolTrue3 = "1";
        private const string CondTypeBoolTrue4 = "";

        private string field;
        private string fieldName;
        private string _operator;
        private string type;
        private bool useFieldValue;
        private string value;

        public override bool Validate(object sender, EventArgs e)
        {
            object fieldValue = null;
           
            var claim = sender as Dictionary<string, object>;

            if (claim == null || string.IsNullOrEmpty(field))
            {
                return false;
            }

            if (useFieldValue)
            {
                fieldValue = claim.GetValueFromToken(fieldName);
            }

            switch (_operator.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondOprContains:
                    {
                        return ValidateCondOprContains(claim, fieldValue);
                    }
                case CondOprNotEqual:
                case CondOprNotEqual2:
                    {
                        return ValidateCondOprNotEqual(claim, fieldValue);
                    }
                case CondOprEqual:
                case CondOprEqual2:
                    {
                        return ValidateCondOprEqual(claim, fieldValue);
                    }
                case CondOprOver:
                case CondOprOver2:
                    {
                        return ValidateCondOprOver(claim, fieldValue);
                    }
                case CondOprBelow:
                case CondOprBelow2:
                    {
                        return ValidateCondOprBelow(claim, fieldValue);
                    }
                case CondOprEqualOwer:
                case CondOprEqualOwer2:
                    {
                        return ValidateCondOprEqualOwer(claim, fieldValue);
                    }
                case CondOprEqualBelow:
                case CondOprEqualBelow2:
                    {
                        return ValidateCondOprEqualBelow(claim, fieldValue);
                    }
                case CondOprNull:
                    {
                        return ValidateCondOprNull(claim);
                    }
                case CondOprNotNull:
                    {
                        return ValidateCondOprNotNull(claim);
                    }
                case CondOprNone:
                    {
                        return ValidateCondOprNone(claim);
                    }
                case CondOprNotNone:
                    {
                        return ValidateCondOprNotNone(claim);
                    }
            }
            return false;
        }

        private bool ValidateCondOprNotNone(Dictionary<string, object> claim)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeString:
                    {
                        return(claim.GetValueFromToken(field) != null || (!string.IsNullOrEmpty((string)claim.GetValueFromToken(field))));
                        
                    }
                case CondTypeInt:
                    {
                        return(((int)claim.GetValueFromToken(field)) != 0);
                        
                    }
                case CondTypeDecimal:
                    {
                        return(((decimal)claim.GetValueFromToken(field)) != 0);
                        
                    }
                case CondTypeDate:
                    {
                        return(claim.GetValueFromToken(field) != null);
                        
                    }
                case CondTypeBool:
                    {
                        //not supported
                        break;
                    }
            }
            return false;
        }

        private bool ValidateCondOprNone(Dictionary<string, object> claim)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeString:
                    {
                        return(claim.GetValueFromToken(field) == null || (string.IsNullOrEmpty((string)claim.GetValueFromToken(field))));
                        
                    }
                case CondTypeInt:
                    {
                        return(((int)claim.GetValueFromToken(field)) == 0);
                        
                    }
                case CondTypeDecimal:
                    {
                        return(((decimal)claim.GetValueFromToken(field)) == 0);
                        
                    }
                case CondTypeDate:
                    {
                        return(claim.GetValueFromToken(field) == null);
                        
                    }
                case CondTypeBool:
                    {
                        //not supported
                        break;
                    }
            }
            return false;
        }

        private bool ValidateCondOprNotNull(Dictionary<string, object> claim)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeInt:
                case CondTypeDecimal:
                case CondTypeBool:
                    {
                        //not supported
                        break;
                    }
                case CondTypeString:
                    {
                        return(claim.GetValueFromToken(field) != null);
                        
                    }
                case CondTypeDate:
                    {
                        return(claim.GetValueFromToken(field) != null);
                        
                    }
            }
            return false;
        }

        private bool ValidateCondOprNull(Dictionary<string, object> claim)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeString:
                    {
                        return(claim.GetValueFromToken(field) == null);
                        
                    }
                case CondTypeDate:
                    {
                        return(claim.GetValueFromToken(field) == null);
                        
                    }
                case CondTypeInt:
                case CondTypeDecimal:
                case CondTypeBool:
                    {
                        //not supported
                    }
                    break;
            }
            return false;
        }

        private bool ValidateCondOprEqualBelow(Dictionary<string, object> claim, object fieldValue)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeInt:
                    {
                        if (!useFieldValue)
                        {
                            return (((int)claim.GetValueFromToken(field)) <= int.Parse(value, CultureInfo.CurrentCulture));
                        }
                        if (fieldValue != null)
                        {
                            return (((int)Common.ExtensionMethods.GetValueFromToken(claim, field)) <= (int)fieldValue);
                        }
                    }
                    break;
                case CondTypeDecimal:
                    {
                        if (useFieldValue)
                        {
                            return (((decimal)claim.GetValueFromToken(field)) <= (decimal)fieldValue);
                        }
                        return (((decimal)claim.GetValueFromToken(field)) <= decimal.Parse(value, CultureInfo.CurrentCulture));
                    }
                case CondTypeBool:
                case CondTypeString:
                    {
                        //Not supported
                        break;
                    }
            }
            return false;
        }

        private bool ValidateCondOprEqualOwer(Dictionary<string, object> claim, object fieldValue)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeString:
                    {
                        //Not supported
                        break;
                    }
                case CondTypeInt:
                    {
                        if (useFieldValue && fieldValue != null)
                        {
                            return(((int)claim.GetValueFromToken(field)) >= (int)fieldValue);
                            
                        }

                        return(((int)claim.GetValueFromToken(field)) >= int.Parse(value, CultureInfo.CurrentCulture));
                        
                    }
                case CondTypeDecimal:
                    {
                        if (useFieldValue)
                        {
                            return(((decimal)claim.GetValueFromToken(field)) >= (decimal)fieldValue);
                            
                        }
                        return(((decimal)claim.GetValueFromToken(field)) >= decimal.Parse(value, CultureInfo.CurrentCulture));
                        
                    }
                case CondTypeBool:
                    {
                        //not supported
                        break;
                    }
            }
            return false;
        }

        private bool ValidateCondOprBelow(Dictionary<string, object> claim, object fieldValue)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeString:
                    {
                        if (useFieldValue)
                        {
                            return(((string)claim.GetValueFromToken(field)) == (string)fieldValue);
                        }

                        return(((string)claim.GetValueFromToken(field)) == value);
                    }
                case CondTypeInt:
                    {
                        if (!useFieldValue)
                        {
                            return(((int)claim.GetValueFromToken(field)) < int.Parse(value, CultureInfo.CurrentCulture));
                        }

                        if (fieldValue != null)
                        {
                            return(((int)Common.ExtensionMethods.GetValueFromToken(claim, field)) < (int)fieldValue);
                        }
                    }
                    break;
                case CondTypeDecimal:
                    {
                        if (useFieldValue)
                        {
                            return(((decimal)claim.GetValueFromToken(field)) < (decimal)fieldValue);
                        }
                        return(((decimal)claim.GetValueFromToken(field)) < decimal.Parse(value, CultureInfo.CurrentCulture));
                    }
                case CondTypeBool:
                    {
                        //not supported
                        break;
                    }
            }
            return false;
        }

        private bool ValidateCondOprOver(Dictionary<string, object> claim, object fieldValue)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeInt:
                    {
                        if (!useFieldValue)
                        {
                            return(((int)claim.GetValueFromToken(field)) > int.Parse(value, CultureInfo.CurrentCulture));
                        }
                        if (fieldValue != null)
                        {
                            return(((int)Common.ExtensionMethods.GetValueFromToken(claim, field)) > (int)fieldValue);
                        }
                    }
                    break;
                case CondTypeDecimal:
                    {
                        if (useFieldValue)
                        {
                            return(((decimal)claim.GetValueFromToken(field)) > (decimal)fieldValue);
                        }
                        return(((decimal)claim.GetValueFromToken(field)) > decimal.Parse(value, CultureInfo.CurrentCulture));
                    }
                case CondTypeBool:
                case CondTypeString:
                    {
                        //not supported
                        break;
                    }
            }
            return false;
        }

        private bool ValidateCondOprEqual(Dictionary<string, object> claim, object fieldValue)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeString:
                    {
                        if (useFieldValue && fieldValue != null)
                        {
                            return ((Convert.ToString(claim.GetValueFromToken(field), CultureInfo.CurrentCulture)).ToLower(CultureInfo.CurrentCulture) == ((string)fieldValue).ToLower(CultureInfo.CurrentCulture));
                        }

                        return ((Convert.ToString(claim.GetValueFromToken(field), CultureInfo.CurrentCulture)).ToLower(CultureInfo.CurrentCulture) == value.ToLower(CultureInfo.CurrentCulture));
                    }
                case CondTypeInt:
                    {
                        if (!useFieldValue)
                        {
                            return (((int)claim.GetValueFromToken(field)) == int.Parse(value, CultureInfo.CurrentCulture));
                        }

                        if (fieldValue != null)
                        {
                            return (((int)claim.GetValueFromToken(field)) == (int)fieldValue);
                        }
                    }
                    break;
                case CondTypeDecimal:
                    {
                        if (useFieldValue)
                        {
                            return (((decimal)claim.GetValueFromToken(field)) == (decimal)fieldValue);
                        }

                        return (((decimal)claim.GetValueFromToken(field)) == decimal.Parse(value, CultureInfo.CurrentCulture));
                    }
                case CondTypeDate:
                    {
                        if (!useFieldValue)
                        {
                            return (((DateTime)claim.GetValueFromToken(field)) == DateTime.Parse(value, CultureInfo.CurrentCulture));
                        }

                        if (fieldValue != null)
                        {
                            return (((DateTime)claim.GetValueFromToken(field)) == (DateTime)fieldValue);
                        }
                    }
                    break;
                case CondTypeBool:
                    {
                        if (!useFieldValue)
                        {
                            bool boolValue = value.ToUpper(CultureInfo.CurrentCulture).Equals(CondTypeBoolTrue) ||
                                             value.ToUpper(CultureInfo.CurrentCulture).Equals(CondTypeBoolTrue2) ||
                                             value.ToUpper(CultureInfo.CurrentCulture).Equals(CondTypeBoolTrue3) ||
                                             string.IsNullOrEmpty(value.ToUpper(CultureInfo.CurrentCulture));

                            return ((Convert.ToBoolean(claim.GetValueFromToken(field), CultureInfo.CurrentCulture)) == boolValue);
                        }

                        if (fieldValue != null)
                        {
                            return (((bool)claim.GetValueFromToken(field)) == (bool)fieldValue);
                        }
                    }
                    break;
            }
            return false;
        }

        private bool ValidateCondOprNotEqual(Dictionary<string, object> claim, object fieldValue)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeString:
                    {
                        if (!useFieldValue)
                        {
                            return (((string)claim.GetValueFromToken(field)).ToLower(CultureInfo.CurrentCulture) != value.ToLower(CultureInfo.CurrentCulture));
                        }
                        if (fieldValue != null)
                        {
                            return (((string)claim.GetValueFromToken(field)).ToLower(CultureInfo.CurrentCulture) != ((string)fieldValue).ToUpper(CultureInfo.CurrentCulture));
                        }
                    }
                    break;
                case CondTypeInt:
                    {
                        if (!useFieldValue)
                        {
                            return (((int)claim.GetValueFromToken(field)) != int.Parse(value, CultureInfo.CurrentCulture));
                        }
                        if (fieldValue != null)
                        {
                            return (((int)claim.GetValueFromToken(field)) != (int)fieldValue);                        }
                    }
                    break;
                case CondTypeDecimal:
                    {
                        if (useFieldValue)
                        {
                            return (((decimal)claim.GetValueFromToken(field)) != (decimal)fieldValue);
                        }
                        return (((decimal)claim.GetValueFromToken(field)) != decimal.Parse(value, CultureInfo.CurrentCulture));
                    }
                case CondTypeDate:
                    {
                        if (useFieldValue)
                        {
                            var val = claim.GetValueFromToken(field);
                            if (val == null)
                            {
                                return false;
                            }
                            if (fieldValue != null)
                            {
                                return (((DateTime)val) != (DateTime)fieldValue);
                            }
                        }
                        else
                        {
                            var val = claim.GetValueFromToken(field);
                            return val != null && ((DateTime)val) != DateTime.Parse(value, CultureInfo.CurrentCulture);
                        }
                    }
                    break;
                case CondTypeBool:
                    {
                        if (useFieldValue)
                        {
                            if (fieldValue != null)
                            {
                                return (((bool)claim.GetValueFromToken(field)) != (bool)fieldValue);
                            }
                        }
                        else
                        {
                            bool boolValue = value.ToUpper(CultureInfo.CurrentCulture).Equals(CondTypeBoolTrue) ||
                                             value.ToUpper(CultureInfo.CurrentCulture).Equals(CondTypeBoolTrue2) ||
                                             value.ToUpper(CultureInfo.CurrentCulture).Equals(CondTypeBoolTrue3) ||
                                             string.IsNullOrEmpty(value.ToUpper(CultureInfo.CurrentCulture));

                            return (((bool)claim.GetValueFromToken(field)) != boolValue);
                        }
                    }
                    break;
            }
            return false;
        }

        private bool ValidateCondOprContains(Dictionary<string, object> claim, object fieldValue)
        {
            switch (type.ToUpper(CultureInfo.CurrentCulture))
            {
                case CondTypeString:
                    {
                        if (!useFieldValue)
                        {
                            return (((string)claim.GetValueFromToken(field)).Contains(value.ToLower(CultureInfo.CurrentCulture)));
                        }

                        if (fieldValue != null)
                        {
                            return (((string)claim.GetValueFromToken(field)).ToLower(CultureInfo.CurrentCulture).Contains(((string)fieldValue).ToLower(CultureInfo.CurrentCulture)));
                        }
                    }
                    break;
            }
            return false;
        }

        public override void Init(string conditionName, string initializedValue, XmlElement settings)
        {
            if (settings == null) return;

            field = "";
            _operator = "";
            value = "";
            type = "";

            field = settings.GetAttribute("field");
            _operator = settings.GetAttribute("operator");
            if (string.IsNullOrEmpty(settings.GetAttribute("fieldvalue")))
            {
                value = settings.GetAttribute("value");
                useFieldValue = false;
            }
            else
            {
                fieldName = settings.GetAttribute("fieldvalue");
                useFieldValue = true;
            }
            type = settings.GetAttribute("type");

            if (string.IsNullOrEmpty(type)) type = CondTypeString;
            if (string.IsNullOrEmpty(_operator)) type = CondOprEqual;
        }

    }
}