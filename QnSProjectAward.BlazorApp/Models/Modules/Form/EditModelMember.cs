//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Models.Modules.Common;
using QnSProjectAward.BlazorApp.Modules.Common;
using QnSProjectAward.BlazorApp.Shared.Components;
using Radzen;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public partial class EditModelMember : ModelMember
    {
        public CommonComponent CommonComponent { get; init; }
        public ReadonlyMode ReadonlyMode => DisplayInfo.ReadonlyMode;
        public VisibilityMode VisibilityMode => DisplayInfo.VisibilityMode;
        public bool Visible
        {
            get
            {
                var result = (VisibilityMode & VisibilityMode.Visible) > 0;

                if (Model is IdentityModel im)
                {
                    result = (im.Id > 0 && (VisibilityMode & VisibilityMode.UpdateView) > 0)
                              ||
                             (im.Id == 0 && (VisibilityMode & VisibilityMode.CreateView) > 0);
                }
                return result;
            }
        }
        public bool Readonly
        {
            get
            {
                var result = (VisibilityMode & VisibilityMode.Visible) > 0;

                if (Model is IdentityModel im)
                {
                    result = (im.Id > 0 && (ReadonlyMode & ReadonlyMode.Update) > 0)
                              ||
                             (im.Id == 0 && (ReadonlyMode & ReadonlyMode.Create) > 0);
                }
                return result;
            }
        }
        public string DefaultValue => PropertyAttribute != null ? PropertyAttribute.DefaultValue : string.Empty;
        public string HtmlCssClass { get; set; }
        public string HtmlAttributes { get; set; }
        public string HtmlFormatString { get; set; }
        public IEnumerable<SelectItem> SelectItems { get; protected set; }
        public ControlType EditCtrlType { get; protected set; }
        public ModelError LastError { get; private set; }
        public virtual object EditValue
        {
            get => Value;
            set
            {
                try
                {
                    var result = value.TryParse(PropertyInfo.PropertyType, out object typeValue);

                    if (result)
                    {
                        PropertyInfo.SetValue(Model, typeValue);
                        LastError = null;
                    }
                    else
                    {
                        LastError = new ModelError(FullName, "The input for {0} cannot be converted.", new object[] { FullName });
                        ShowError(LastError);
                    }
                }
                catch (Exception ex)
                {
                    LastError = new ModelError(FullName, ex.Message);
                    ShowError(LastError);
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
        public virtual string EditStringValue
        {
            get
            {
                return Value?.ToString();
            }
            set
            {
                if (PropertyInfo.PropertyType.Equals(typeof(string)))
                {
                    EditValue = value;
                }
                else if (PropertyInfo.PropertyType.IsNullableType() && string.IsNullOrEmpty(value))
                {
                    EditValue = null;
                }
                else
                {
                    EditValue = value;
                }
            }
        }

        public virtual bool EditBoolValue
        {
            get
            {
                return Value != null && bool.TryParse(Value.ToString(), out bool tmpValue) && tmpValue;
            }
            set => EditValue = value;
        }

        public virtual char EditCharValue
        {
            get => TryParse<char>(Value, char.TryParse);
            set => EditValue = value;
        }
        public virtual sbyte EditSByteValue
        {
            get => TryParse<sbyte>(Value, sbyte.TryParse);
            set => EditValue = value;
        }
        public virtual byte EditByteValue
        {
            get => TryParse<byte>(Value, byte.TryParse);
            set => EditValue = value;
        }
        public virtual short EditShortValue
        {
            get => TryParse<short>(Value, short.TryParse);
            set => EditValue = value;
        }
        public virtual ushort EditUShortValue
        {
            get => TryParse<ushort>(Value, ushort.TryParse);
            set => EditValue = value;
        }
        public virtual int EditIntValue
        {
            get => TryParse<int>(Value, int.TryParse);
            set => EditValue = value;
        }
        public virtual uint EditUIntValue
        {
            get => TryParse<uint>(Value, uint.TryParse);
            set => EditValue = value;
        }
        public virtual long EditLongValue
        {
            get => TryParse<long>(Value, long.TryParse);
            set => EditValue = value;
        }
        public virtual ulong EditULongValue
        {
            get => TryParse<ulong>(Value, ulong.TryParse);
            set => EditValue = value;
        }
        public virtual float EditFloatValue
        {
            get => TryParse<float>(Value, float.TryParse);
            set => EditValue = value;
        }
        public virtual double EditDoubleValue
        {
            get => TryParse<double>(Value, double.TryParse);
            set => EditValue = value;
        }
        public virtual decimal EditDecimalValue
        {
            get => TryParse<decimal>(Value, decimal.TryParse);
            set => EditValue = value;
        }
        public virtual DateTime EditDateTimeValue
        {
            get => (DateTime)Value == default ? CreateDefaultDateTime() : TryParse<DateTime>(Value, DateTime.TryParse);
            set => EditValue = (DateTime)value == CreateDefaultDateTime() ? default : value;
        }
        public virtual TimeSpan EditTimeSpanValue
        {
            get => TryParse<TimeSpan>(Value, TimeSpan.TryParse);
            set => EditValue = value;
        }
        public virtual DateTime EditTimeValue
        {
            get => CreateNowDate(EditTimeSpanValue);
            set => EditTimeSpanValue = CreateTimeSpan(value);
        }

        public virtual char? EditCharNullValue
        {
            get => TryParse<char>(Value, char.TryParse);
            set => EditValue = value;
        }
        public virtual sbyte? EditSByteNullValue
        {
            get => TryParse<sbyte>(Value, sbyte.TryParse);
            set => EditValue = value;
        }
        public virtual byte? EditByteNullValue
        {
            get => TryParse<byte>(Value, byte.TryParse);
            set => EditValue = value;
        }
        public virtual short? EditShortNullValue
        {
            get => TryParse<short>(Value, short.TryParse);
            set => EditValue = value;
        }
        public virtual ushort? EditUShortNullValue
        {
            get => TryParse<ushort>(Value, ushort.TryParse);
            set => EditValue = value;
        }
        public virtual int? EditIntNullValue
        {
            get => TryParse<int>(Value, int.TryParse);
            set => EditValue = value;
        }
        public virtual uint? EditUIntNullValue
        {
            get => TryParse<uint>(Value, uint.TryParse);
            set => EditValue = value;
        }
        public virtual long? EditLongNullValue
        {
            get => TryParse<long>(Value, long.TryParse);
            set => EditValue = value;
        }
        public virtual ulong? EditULongNullValue
        {
            get => TryParse<ulong>(Value, ulong.TryParse);
            set => EditValue = value;
        }
        public virtual float? EditFloatNullValue
        {
            get => TryParse<float>(Value, float.TryParse);
            set => EditValue = value;
        }
        public virtual double? EditDoubleNullValue
        {
            get => TryParse<double>(Value, double.TryParse);
            set => EditValue = value;
        }
        public virtual decimal? EditDecimalNullValue
        {
            get => TryParse<decimal>(Value, decimal.TryParse);
            set => EditValue = value;
        }
        public virtual DateTime? EditDateTimeNullValue
        {
            get => Value == null ? CreateDefaultDateTime() : TryParse<DateTime>(Value, DateTime.TryParse);
            set => EditValue = value == CreateDefaultDateTime() ? null : value;
        }
        public virtual TimeSpan? EditTimeSpanNullValue
        {
            get => TryParse<TimeSpan>(Value, TimeSpan.TryParse);
            set => EditValue = value;
        }
        public virtual DateTime? EditTimeNullValue
        {
            get => CreateNowDateNull(EditTimeSpanNullValue);
            set => EditTimeSpanNullValue = CreateTimeSpanNull(value);
        }

        private string saveNumericValue;
        public virtual string EditNumericValue
        {
            get
            {
                return (saveNumericValue == null ? Value : LastError != null ? Value : saveNumericValue)?.ToString();
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    EditValue = saveNumericValue = null;
                }
                else
                {
                    EditValue = saveNumericValue = value;
                }
            }
        }

        public EditModelMember(CommonComponent commonComponent, ModelObject model, PropertyInfo propertyInfo, DisplayProperty displayProperty)
            : base(model, propertyInfo, displayProperty)
        {
            commonComponent.CheckArgument(nameof(commonComponent));

            CommonComponent = commonComponent;
            if (propertyInfo.PropertyType.Equals(typeof(string)))
            {
                if (MaxLength > 100)
                    EditCtrlType = ControlType.TextArea;
                else
                    EditCtrlType = ControlType.TextBox;
            }
            else if (PropertyInfo.PropertyType.IsEnum)
            {
                EditCtrlType = ControlType.Select;
                SelectItems = Selector.LoadEnumLiterals(PropertyInfo.PropertyType, Value, null);
            }
            else if (PropertyInfo.PropertyType.Equals(typeof(TimeSpan)))
            {
                EditCtrlType = ControlType.TimePicker;
                FormatValue = "HH:mm";
            }
            else if (PropertyInfo.PropertyType.Equals(typeof(TimeSpan?)))
            {
                EditCtrlType = ControlType.TimePickerNull;
                FormatValue = "HH:mm";
            }
            else if (PropertyInfo.PropertyType.Equals(typeof(DateTime)))
            {
                EditCtrlType = ControlType.DatePicker;
                FormatValue = "dd.MM.yyyy";
                if (ContentType == CommonBase.Attributes.ContentType.DateTime)
                {
                    EditCtrlType = ControlType.DateTimePicker;
                    FormatValue += " HH:mm:ss";
                }
            }
            else if (PropertyInfo.PropertyType.Equals(typeof(DateTime?)))
            {
                EditCtrlType = ControlType.DatePickerNull;
                FormatValue = "dd.MM.yyyy";
                if (ContentType == CommonBase.Attributes.ContentType.DateTime)
                {
                    EditCtrlType = ControlType.DateTimePickerNull;
                    FormatValue += " HH:mm:ss";
                }
            }
            else if (PropertyInfo.PropertyType.Equals(typeof(bool)))
            {
                EditCtrlType = ControlType.CheckBox;
            }
            else if (PropertyInfo.PropertyType.Equals(typeof(bool?)))
            {
                EditCtrlType = ControlType.CheckBoxNull;
            }
            else if (PropertyInfo.PropertyType.IsNumericType())
            {
                if (PropertyInfo.PropertyType.IsNullableType())
                {
                    EditCtrlType = ControlType.NumericNull;
                    if (PropertyInfo.PropertyType.IsFloatingPointType())
                        EditCtrlType = ControlType.FloatingPointNull;
                }
                else
                {
                    EditCtrlType = ControlType.Numeric;
                    if (PropertyInfo.PropertyType.IsFloatingPointType())
                        EditCtrlType = ControlType.FloatingPoint;
                }
            }
        }

        private void ShowError(ModelError modelError)
        {
            CommonComponent.NotificationService.Notify(new NotificationMessage()
            {
                Severity = NotificationSeverity.Error,
                Summary = modelError.Key,
                Detail = modelError.Message,
                Duration = 4000
            });
        }

        #region Helpers
        public static DateTime CreateDefaultDateTime()
        {
            return new DateTime();// new DateTime(1, 1, 1, 1, 1, 1, 1);
        }
        public static DateTime CreateNowDate()
        {
            var result = DateTime.Now;

            result = result.AddHours(-result.Hour);
            result = result.AddMinutes(-result.Minute);
            result = result.AddSeconds(-result.Second);
            return result;
        }
        public static DateTime CreateNowDate(TimeSpan timeSpan)
        {
            var result = CreateNowDate();

            result = result.AddHours(timeSpan.Hours);
            result = result.AddMinutes(timeSpan.Minutes);
            result = result.AddSeconds(timeSpan.Seconds);
            return result;
        }
        public static TimeSpan CreateTimeSpan(DateTime dateTime)
        {
            return new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        public static DateTime? CreateNowDateNull(TimeSpan? timeSpan)
        {
            return timeSpan != null ? CreateNowDate(timeSpan.Value) : null;
        }
        public static TimeSpan? CreateTimeSpanNull(DateTime? dateTime)
        {
            return dateTime != null ? CreateTimeSpan(dateTime.Value) : null;
        }

        private delegate bool TryParseHandler<T>(string value, out T result);
        private static T TryParse<T>(object value, TryParseHandler<T> tryParse)
        {
            tryParse.CheckArgument(nameof(tryParse));

            return value != null ? tryParse(value.ToString(), out T tmpValue) ? tmpValue : default : default;
        }
        #endregion Helpers
    }
}
//MdEnd
