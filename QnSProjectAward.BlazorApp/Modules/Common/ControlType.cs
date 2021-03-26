//@QnSCodeCopy
//MdStart
using System;

namespace QnSProjectAward.BlazorApp.Modules.Common
{
    [Flags]
    public enum ControlType : int
    {
        TextBox = 1,
        TextArea = 2,
        Numeric = 4,
        NumericNull = 8,
        FloatingPoint = 16,
        FloatingPointNull = 32,
        Select = 64,
        SelectNull = 128,
        TimePicker = 256,
        TimePickerNull = 512,
        DatePicker = 1024,
        DatePickerNull = 2048,
        DateTimePicker = 2048 * 2,
        DateTimePickerNull = 2048 * 4,
        CheckBox = 2 * 2048 * 8,
        CheckBoxNull = 4 * 2048 * 16,

        ValidateType = TextBox + TextArea + Numeric + FloatingPoint + DatePicker + TimePicker,
    }
}
//MdEnd
